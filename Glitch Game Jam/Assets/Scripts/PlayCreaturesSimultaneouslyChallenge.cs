using UnityEngine;

[CreateAssetMenu(fileName = "New Play Creatures Simultaneously Challenge", menuName = "Challenges/Play Creatures Simultaneously")]
public class PlayCreaturesSimultaneouslyChallenge : Challenge
{
    public int creaturesToSummon;
    private int creaturesSummonedThisTurn;

    public override void Setup()
    {
        creaturesSummonedThisTurn = 0;
        GameState.Instance.OnRoundStart += ResetSummonedCreatures;
        GameState.Instance.OnCreatureSummoned += HandleCreatureSummoned;
    }

    public override void Teardown()
    {
        if (GameState.Instance != null)
        {
            GameState.Instance.OnRoundStart -= ResetSummonedCreatures;
            GameState.Instance.OnCreatureSummoned -= HandleCreatureSummoned;
        }
    }

    public override bool IsCompleted()
    {
        return creaturesSummonedThisTurn >= creaturesToSummon;
    }

    private void ResetSummonedCreatures()
    {
        creaturesSummonedThisTurn = 0;
    }

    private void HandleCreatureSummoned(Creature creature)
    {
        creaturesSummonedThisTurn++;
    }
}
