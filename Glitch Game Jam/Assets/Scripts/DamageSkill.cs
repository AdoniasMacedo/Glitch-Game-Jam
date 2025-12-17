using UnityEngine;

[System.Serializable]
public class DamageSkill : Skills
{
    public int damageAmount;
    public Creature target;

    public override void Apply()
    {
        if (target != null)
        {
            target.TakeDamage(damageAmount);
        }
    }
}
