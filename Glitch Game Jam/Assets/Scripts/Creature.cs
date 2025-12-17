using UnityEngine;

public class Creature : MonoBehaviour
{
    public string creatureName;

    private void OnEnable()
    {
        CreatureRegistry.Register(this);
    }

    private void OnDisable()
    {
        CreatureRegistry.Unregister(this);
    }

    public void TakeDamage(int amount)
    {
        // Placeholder for damage logic
    }

    public void Heal(int amount)
    {
        // Placeholder for healing logic
    }
}
