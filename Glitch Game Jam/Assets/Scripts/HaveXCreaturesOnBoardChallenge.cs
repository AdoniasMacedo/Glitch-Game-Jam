using UnityEngine;

[CreateAssetMenu(fileName = "New Have X Creatures On Board Challenge", menuName = "Challenges/Have X Creatures On Board")]
public class HaveXCreaturesOnBoardChallenge : Challenge
{
    public int creaturesToHave;

    public override bool IsCompleted(GameState gameState)
    {
        return gameState.creaturesOnBoard >= creaturesToHave;
    }
}
