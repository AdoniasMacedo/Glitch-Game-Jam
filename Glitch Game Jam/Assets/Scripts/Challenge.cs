using UnityEngine;

[CreateAssetMenu(fileName = "New Challenge", menuName = "Challenges/Challenge")]
public abstract class Challenge : ScriptableObject
{
    public string description;

    public abstract bool IsCompleted(GameState gameState);
}
