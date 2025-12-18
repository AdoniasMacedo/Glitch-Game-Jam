using UnityEngine;

[CreateAssetMenu(fileName = "New Heal All Creatures Blessing", menuName = "Blessings/Heal All Creatures")]
public class HealAllCreaturesBlessing : Blessing
{
    public int healAmount;

    public override void UpdateBlessing()
    {
        if (duration > 0)
        {
            foreach (var creature in CreatureRegistry.Instance.ActiveCreatures)
            {
                // Assuming Creature has a Heal method
                creature.Heal(healAmount);
            }
        }
        base.UpdateBlessing();
    }
}
