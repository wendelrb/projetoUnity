using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configuração de Vida")]
    public int maxHealth = 5;
    private int currentHealth;

    public UnityEvent onDeath; // para avisar quando morrer

    private void Awake()
    {
        currentHealth = maxHealth;
        
    }

    private void Start()
    {
        PlayerHealthUI.Instance.InitHealthBar(maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Player tomou dano. Vida atual: " + currentHealth);

        // Atualiza UI
        PlayerHealthUI.Instance.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player morreu!");
        onDeath.Invoke(); // dispara evento de morte (vai ser usado no fim de fase)
    }
}



/*
FUNFANDO
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int CurrentHp => hp;

    public int maxHp = 5;
    int hp;

    void Start()
    {
        hp = maxHp;
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0) Die();
    }

    void Die()
    {
        // Simples: reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
*/