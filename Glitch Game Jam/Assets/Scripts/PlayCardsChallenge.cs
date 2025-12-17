using UnityEngine;

[CreateAssetMenu(fileName = "New Play Cards Challenge", menuName = "Challenges/Play Cards")]
public class PlayCardsChallenge : Challenge
{
    public int cardsToPlay;
    private int cardsPlayed;

    public override void Setup()
    {
        cardsPlayed = 0;
        GameState.Instance.OnCardPlayed += HandleCardPlayed;
    }

    public override void Teardown()
    {
        if (GameState.Instance != null)
        {
            GameState.Instance.OnCardPlayed -= HandleCardPlayed;
        }
    }

    public override bool IsCompleted()
    {
        return cardsPlayed >= cardsToPlay;
    }

    private void HandleCardPlayed(Card card)
    {
        cardsPlayed++;
    }
}
