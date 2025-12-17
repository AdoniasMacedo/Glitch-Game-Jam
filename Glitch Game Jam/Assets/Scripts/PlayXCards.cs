using UnityEngine;

[CreateAssetMenu(fileName = "New Play X Cards Challenge", menuName = "Challenges/Play X Cards")]
public class PlayXCards : Challenge
{
    public int cardsToPlay;

    public override bool IsCompleted(GameState gameState)
    {
        return gameState.playedCards >= cardsToPlay;
    }
}
