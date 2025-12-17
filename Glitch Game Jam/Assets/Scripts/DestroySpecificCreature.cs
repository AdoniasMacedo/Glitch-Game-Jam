using UnityEngine;

[CreateAssetMenu(fileName = "New Destroy Specific Creature Challenge", menuName = "Challenges/Destroy Specific Creature")]
public class DestroySpecificCreature : Challenge
{
    public Card creatureToDestroy;

    public override bool IsCompleted(GameState gameState)
    {
        return gameState.destroyedCreaturesList.Contains(creatureToDestroy);
    }
}
