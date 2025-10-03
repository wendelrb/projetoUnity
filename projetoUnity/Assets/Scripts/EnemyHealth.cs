using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Configuração de Vida")]
    public int maxHealth = 3;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(gameObject.name + " tomou " + amount + " de dano. Vida atual: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Aqui você pode adicionar animação, drop, efeitos etc.
        Debug.Log(gameObject.name + " morreu!");
        Destroy(gameObject);
    }
}
