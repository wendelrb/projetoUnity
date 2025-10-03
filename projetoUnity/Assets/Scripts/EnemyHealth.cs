using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Configuração de Vida")]
    public int maxHp = 3;   // vida máxima do inimigo
    private int hp;

    void Start()
    {
        hp = maxHp;
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        Debug.Log($"{name} levou {amount} de dano! Vida = {hp}");

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{name} morreu!");
        Destroy(gameObject); // inimigo desaparece
    }
}
