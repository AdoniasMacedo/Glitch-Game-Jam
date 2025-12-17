using UnityEngine;

[CreateAssetMenu(fileName = "New Survive Rounds Challenge", menuName = "Challenges/Survive Rounds")]
public class SurviveRoundsChallenge : Challenge
{
    public int roundsToSurvive;
    private int roundsSurvived;

    public override void Setup()
    {
        roundsSurvived = 0;
        GameState.Instance.OnRoundEnd += HandleRoundEnd;
    }

    public override void Teardown()
    {
        if (GameState.Instance != null)
        {
            GameState.Instance.OnRoundEnd -= HandleRoundEnd;
        }
    }

    public override bool IsCompleted()
    {
        return roundsSurvived >= roundsToSurvive;
    }

    private void HandleRoundEnd()
    {
        roundsSurvived++;
    }
}
