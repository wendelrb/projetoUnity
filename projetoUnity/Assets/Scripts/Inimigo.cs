using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyFollowerJump : MonoBehaviour
{
    [Header("Quem seguir")]
    public Transform target;

    [Header("Movimentação")]
    public float moveSpeed = 3f;    // velocidade de andar
    public float jumpForce = 8f;    // força do pulo
    public float groundCheckRadius = 0.2f; // raio para checar o chão
    public LayerMask groundLayer;   // camada do chão

    private Rigidbody2D rb;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3f; // mesma gravidade do player
        rb.freezeRotation = true;
    }

    void Start()
    {
        if (target == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null) target = player.transform;
        }
    }

    void Update()
    {
        CheckGround();

        if (target != null)
        {
            // Movimento horizontal em direção ao player
            float direction = Mathf.Sign(target.position.x - transform.position.x);
            rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);

            // Se o player estiver acima e inimigo estiver no chão → pula
            if (target.position.y > transform.position.y + 0.5f && isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    void CheckGround()
    {
        // Raycast para verificar se está tocando o chão
        isGrounded = Physics2D.OverlapCircle(transform.position + Vector3.down * 0.5f, groundCheckRadius, groundLayer);
    }

    // Desenha o raio de checagem no editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * 0.5f, groundCheckRadius);
    }
}
