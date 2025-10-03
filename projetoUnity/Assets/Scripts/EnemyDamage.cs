using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyDamage : MonoBehaviour
{
    [Header("Configuração de Dano")]
    public int damage = 1;              // Quanto de vida o inimigo tira por ataque
    public float attackCooldown = 1f;   // Intervalo entre ataques (segundos)

    private float lastAttackTime;

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Se colidiu com o Player
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null && Time.time - lastAttackTime >= attackCooldown)
            {
                playerHealth.TakeDamage(damage);
                lastAttackTime = Time.time;
            }
        }
    }
}
