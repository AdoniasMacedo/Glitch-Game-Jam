using UnityEngine;

public class Player : MonoBehaviour
{
    public int essence;
    public int maxEssence;
    public int mana;
    public int maxMana;

    public void TakeDamage(int amount)
    {
        essence -= amount;
        if (essence <= 0)
        {
            essence = 0;
            CombatManager.Instance.state = CombatState.DEFEAT;
        }
    }

    public void Heal(int amount)
    {
        essence += amount;
        if (essence > maxEssence)
        {
            essence = maxEssence;
        }
    }
}
