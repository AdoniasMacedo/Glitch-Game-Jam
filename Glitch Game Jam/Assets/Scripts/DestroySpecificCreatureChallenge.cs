using UnityEngine;

[CreateAssetMenu(fileName = "New Destroy Specific Creature Challenge", menuName = "Challenges/Destroy Specific Creature")]
public class DestroySpecificCreatureChallenge : Challenge
{
    public string creatureName;
    private bool isTargetCreatureDestroyed;

    public override void Setup()
    {
        isTargetCreatureDestroyed = false;
        GameState.Instance.OnCreatureDestroyed += HandleCreatureDestroyed;
    }

    public override void Teardown()
    {
        if (GameState.Instance != null)
        {
            GameState.Instance.OnCreatureDestroyed -= HandleCreatureDestroyed;
        }
    }

    public override bool IsCompleted()
    {
        return isTargetCreatureDestroyed;
    }

    private void HandleCreatureDestroyed(Creature creature)
    {
        if (creature.creatureName == creatureName)
        {
            isTargetCreatureDestroyed = true;
        }
    }
}
