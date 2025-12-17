using UnityEngine;

[CreateAssetMenu(fileName = "New Destroy X Creatures Challenge", menuName = "Challenges/Destroy X Creatures")]
public class DestroyXCreatures : Challenge
{
    public int creaturesToDestroy;

    public override bool IsCompleted(GameState gameState)
    {
        return gameState.destroyedCreatures >= creaturesToDestroy;
    }
}
