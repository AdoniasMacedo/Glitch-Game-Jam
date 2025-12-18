using UnityEngine;

public enum CombatState { PREPARATION, PLAYERTURN, ENEMYTURN, VICTORY, DEFEAT }

public class CombatManager : MonoBehaviour
{
    private static CombatManager _instance;
    public static CombatManager Instance => _instance;

    public CombatState state;

    public ChallengeManager challengeManager;
    public RewardManager rewardManager;
    public BargainManager bargainManager;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void StartPreparationPhase()
    {
        DeckManager.Instance.DrawInitialHand();
        // The MulliganUI will now handle the transition to the player's turn
    }

    public void EndPlayerTurn()
    {
        state = CombatState.ENEMYTURN;
        StartEnemyTurn();
    }

    void StartEnemyTurn()
    {
        bool playerHasCreatures = false;
        foreach (var creature in CreatureRegistry.Instance.ActiveCreatures)
        {
            if (!creature.isEnemy)
            {
                playerHasCreatures = true;
                break;
            }
        }

        if (!playerHasCreatures)
        {
            bool enemyHasCreatures = false;
            foreach (var creature in CreatureRegistry.Instance.ActiveCreatures)
            {
                if (creature.isEnemy)
                {
                    enemyHasCreatures = true;
                    break;
                }
            }

            if(enemyHasCreatures)
            {
                Player player = FindAnyObjectByType<Player>();
                player.TakeDamage(1);
            }
        }

        foreach (var creature in CreatureRegistry.Instance.ActiveCreatures)
        {
            if (creature.isEnemy)
            {
                creature.PerformAction();
            }
        }

        CheckEndCombatConditions();

        if(state != CombatState.VICTORY && state != CombatState.DEFEAT)
        {
            state = CombatState.PLAYERTURN;
        }
    }

    void CheckEndCombatConditions()
    {
        if (challengeManager.activeChallenge.IsCompleted())
        {
            state = CombatState.VICTORY;
            HandleVictory();
        }

        if (state == CombatState.DEFEAT)
        {
            HandleDefeat();
        }
    }

    void HandleVictory()
    {
        rewardManager.TriggerReward(challengeManager.activeChallenge.reward, gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene("ChallengeSelection");
    }

    void HandleDefeat()
    {
        bargainManager.TriggerBargain(challengeManager.activeChallenge.bargain, gameObject);
        rewardManager.TriggerReward(challengeManager.activeChallenge.reward, gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene("ChallengeSelection");
    }

    private void OnEnable()
    {
        GameState.Instance.OnCardPlayed += OnCardPlayed;
        GameState.Instance.OnCreatureDestroyed += OnCreatureDestroyed;
    }

    private void OnDisable()
    {
        GameState.Instance.OnCardPlayed -= OnCardPlayed;
        GameState.Instance.OnCreatureDestroyed -= OnCreatureDestroyed;
    }

    private CardData _currentCardData;
    private Player _player;

    void Start()
    {
        state = CombatState.PREPARATION;
        StartPreparationPhase();
        _player = FindAnyObjectByType<Player>();
    }

    private void OnCardPlayed(CardData cardData)
    {
        if (_player.mana >= cardData.costValue)
        {
            _currentCardData = cardData;
            TargetingSystem.Instance.StartTargeting();
            TargetingSystem.Instance.OnTargetSelected += OnTargetSelected;
        }
    }

    private void OnTargetSelected(Creature target)
    {
        _player.mana -= _currentCardData.costValue;
        /*DeckManager.Instance.hand.Remove(_currentCardData);
        DeckManager.Instance.discardPile.Add(_currentCardData);*/

        foreach (var skill in _currentCardData.skills)
        {
            if (skill is DamageSkill damageSkill)
            {
                damageSkill.target = target;
            }
            else if (skill is HealSkill healSkill)
            {
                healSkill.target = target;
            }
            skill.Apply();
        }

        _currentCardData = null;
        TargetingSystem.Instance.OnTargetSelected -= OnTargetSelected;
    }

    private void OnCreatureDestroyed(Creature creature)
    {
        CheckEndCombatConditions();
    }
}
