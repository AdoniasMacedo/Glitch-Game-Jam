using System;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private static GameState _instance;
    public static GameState Instance => _instance;

    public event Action OnRoundStart;
    public event Action OnRoundEnd;
    public event Action<CardData> OnCardPlayed;
    public event Action<Creature> OnCreatureDestroyed;
    public event Action<Creature> OnCreatureSummoned;

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

    public void StartRound()
    {
        OnRoundStart?.Invoke();
    }

    public void EndRound()
    {
        OnRoundEnd?.Invoke();
    }

    public void CardPlayed(CardData cardData)
    {
        OnCardPlayed?.Invoke(cardData);
    }

    public void CreatureDestroyed(Creature creature)
    {
        OnCreatureDestroyed?.Invoke(creature);
    }

    public void CreatureSummoned(Creature creature)
    {
        OnCreatureSummoned?.Invoke(creature);
    }
}
