using UnityEngine;

[System.Serializable]
public class HealSkill : Skills
{
    public int healAmount;
    public Creature target;

    public override void Apply()
    {
        if (target != null)
        {
            target.Heal(healAmount);
        }
    }
}
