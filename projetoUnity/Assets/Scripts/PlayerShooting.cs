using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerShooting : MonoBehaviour
{
    [Header("Configuração do Tiro")]
    public GameObject bulletPrefab;   // Prefab da bala
    public Transform firePoint;       // Ponto de onde sai o tiro (o eixo X do FirePoint deve apontar para o mouse)
    public float bulletSpeed = 10f;   // Velocidade da bala

    [Header("Som do Tiro")]
    public AudioClip shootSFX;        // Som do disparo
    private AudioSource audioSource;  // Para tocar o som

    private Collider2D playerCollider; // referência ao colisor do Player

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        playerCollider = GetComponent<Collider2D>(); // pega o collider do Player
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Clique esquerdo do mouse
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        // Cria a bala na posição e rotação do firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Aplica velocidade na direção do eixo X do firePoint (MouseAim já cuida de rotacionar)
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.right * bulletSpeed;
        }

        // ⚡ Ignora colisão entre a bala e o Player
        Collider2D bulletCol = bullet.GetComponent<Collider2D>();
        if (playerCollider != null && bulletCol != null)
        {
            Physics2D.IgnoreCollision(bulletCol, playerCollider);
        }

        // Toca som de disparo
        if (shootSFX != null)
            audioSource.PlayOneShot(shootSFX);
    }
}
