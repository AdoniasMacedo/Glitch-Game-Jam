using UnityEngine;

public abstract class Blessing : ScriptableObject
{
    public int duration;
    protected GameObject target;

    public virtual void ApplyBlessing(GameObject target)
    {
        this.target = target;
    }

    public virtual void RemoveBlessing()
    {
    }

    public virtual void UpdateBlessing()
    {
        if (duration > 0)
        {
            duration--;
        }
    }
}
