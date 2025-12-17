using UnityEngine;

[CreateAssetMenu(fileName = "New Destroy Creatures Challenge", menuName = "Challenges/Destroy Creatures")]
public class DestroyCreaturesChallenge : Challenge
{
    public int creaturesToDestroy;
    private int creaturesDestroyed;

    public override void Setup()
    {
        creaturesDestroyed = 0;
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
        return creaturesDestroyed >= creaturesToDestroy;
    }

    private void HandleCreatureDestroyed(Creature creature)
    {
        creaturesDestroyed++;
    }
}
