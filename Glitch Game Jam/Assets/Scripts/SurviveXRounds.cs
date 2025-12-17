using UnityEngine;

[CreateAssetMenu(fileName = "New Survive X Rounds Challenge", menuName = "Challenges/Survive X Rounds")]
public class SurviveXRounds : Challenge
{
    public int roundsToSurvive;

    public override bool IsCompleted(GameState gameState)
    {
        return gameState.currentRound >= roundsToSurvive;
    }
}
