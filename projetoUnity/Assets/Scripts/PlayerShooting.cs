using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;   // Prefab do projétil
    public Transform firePoint;       // Objeto que aponta para o mouse
    public float bulletSpeed = 10f;
    public float muzzleOffset = 0.25f; // distância extra à frente do cano

    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
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
        // Direção até o mouse
        Vector3 mouseWorld = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = ((Vector2)(mouseWorld - firePoint.position)).normalized;

        // Posição com offset para fora do Player
        Vector3 spawnPos = firePoint.position + (Vector3)(dir * muzzleOffset);
        spawnPos.z = 0;

        // Rotação da bala na direção do tiro
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);

        // Instancia a bala
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, rot);

        // Dá velocidade
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = dir * bulletSpeed;
    }
}
