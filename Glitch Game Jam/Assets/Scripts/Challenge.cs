using UnityEngine;

public abstract class Challenge : ScriptableObject
{
    public string challengeName;
    public string challengeDescription;
    public Reward reward;
    public Bargain bargain;

    public abstract void Setup();
    public abstract void Teardown();
    public abstract bool IsCompleted();
}
