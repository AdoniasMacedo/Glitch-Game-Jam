using UnityEngine;

public class Creature : MonoBehaviour
{
    public string creatureName;
    public int health;
    public int maxHealth;
    public int attackPower;
    public bool isEnemy;

    public void PerformAction()
    {
        if (isEnemy)
        {
            // Simple AI: attack the player directly
            Player player = FindAnyObjectByType<Player>();
            if (player != null)
            {
                player.TakeDamage(attackPower);
            }
        }
    }

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
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            GameState.Instance.CreatureDestroyed(this);
            Destroy(gameObject);
        }
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
