using UnityEngine;

public abstract class Consequence : ScriptableObject
{
    public abstract void ApplyConsequence(GameObject target);
}
