using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;          // quanto de dano a bala causa
    public float lifeTime = 2f;     // tempo até sumir

    void Start()
    {
        Destroy(gameObject, lifeTime); // some sozinho depois de X segundos
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Se acertar inimigo
        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // destrói a bala
        }
        else if (!collision.CompareTag("Player"))
        {
            // Se bater em parede/chão/etc, também destrói
            Destroy(gameObject);
        }
    }
}
