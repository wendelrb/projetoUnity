using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;   // Prefab do projétil
    public Transform firePoint;       // Objeto que aponta para o mouse
    public float bulletSpeed = 10f;

    public AudioClip shootSFX;        // Som do tiro
    private AudioSource audioSource;  // Para tocar som

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Mantive a linha do seu script com linearVelocity, só cuidado, talvez precise mudar para velocity
        rb.linearVelocity = firePoint.right * bulletSpeed;

        audioSource.PlayOneShot(shootSFX);  // Toca som do tiro

        Destroy(bullet, 2f); // Destroi a bala depois de 2 segundos
    }
}
