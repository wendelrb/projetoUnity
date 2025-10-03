using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Configuração do Projétil")]
    public int damage = 1;
    public float lifeTime = 2f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Com a Matrix configurada, só Enemy vai chegar aqui
        EnemyHealth enemy = other.GetComponentInParent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        // Qualquer outra coisa (Player/Chão) nem colide por causa da Matrix
    }
}





/*
FUNFANDO


using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;       // Dano que a bala causa
    public float lifeTime = 2f;  // Tempo até sumir sozinho

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Se colidir com inimigo
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // bala desaparece ao atingir inimigo
        }
    }
}
*/
