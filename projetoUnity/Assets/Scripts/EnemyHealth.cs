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
    // verifica se este é o último inimigo antes de destruir
    int count = FindObjectsOfType<EnemyHealth>().Length;
    bool lastOne = count <= 1;

    Destroy(gameObject);

    if (lastOne)
        GameManager.Instance.EndGame(true);
}

}
