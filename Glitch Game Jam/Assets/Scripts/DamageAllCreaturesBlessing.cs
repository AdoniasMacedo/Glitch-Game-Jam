using UnityEngine;

[CreateAssetMenu(fileName = "New Damage All Creatures Blessing", menuName = "Blessings/Damage All Creatures")]
public class DamageAllCreaturesBlessing : Blessing
{
    public int damageAmount;

    public override void UpdateBlessing()
    {
        if (duration > 0)
        {
            foreach (var creature in CreatureRegistry.ActiveCreatures)
            {
                // Assuming Creature has a TakeDamage method
                creature.TakeDamage(damageAmount);
            }
        }
        base.UpdateBlessing();
    }
}
