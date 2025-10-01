using UnityEngine;

public enum EnemyState { Patrol, Chase, Attack }

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 3.5f;
    public Transform pointA;
    public Transform pointB;

    [Header("Detection")]
    public float detectRadius = 5f;
    public float attackRange = 1f;
    public LayerMask playerLayer;

    [Header("Attack")]
    public int hp = 3;
    public int damage = 1;
    public float attackCooldown = 1f;

    Animator animator;
    Rigidbody2D rb;
    Transform player;
    EnemyState state = EnemyState.Patrol;
    Transform currentTarget;
    float attackTimer = 0f;
    bool facingRight = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentTarget = pointB;
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        attackTimer -= Time.deltaTime;

        // Simple detection using distance + OverlapCircle
        if (player != null)
        {
            float dist = Vector2.Distance(transform.position, player.position);
            if (dist <= detectRadius)
            {
                if (dist <= attackRange) state = EnemyState.Attack;
                else state = EnemyState.Chase;
            }
            else state = EnemyState.Patrol;
        }

        switch (state)
        {
            case EnemyState.Patrol: DoPatrol(); break;
            case EnemyState.Chase: DoChase(); break;
            case EnemyState.Attack: DoAttackState(); break;
        }
    }

    void DoPatrol()
    {
        animator.SetFloat("Speed", patrolSpeed);
        MoveTowards(currentTarget.position, patrolSpeed);
        if (Vector2.Distance(transform.position, currentTarget.position) < 0.2f)
        {
            currentTarget = currentTarget == pointA ? pointB : pointA;
            Flip();
        }
    }

    void DoChase()
    {
        if (player == null) { state = EnemyState.Patrol; return; }
        animator.SetFloat("Speed", chaseSpeed);
        MoveTowards(player.position, chaseSpeed);
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
            state = EnemyState.Attack;
    }

    void DoAttackState()
    {
        rb.linearVelocity = Vector2.zero;
        animator.SetFloat("Speed", 0);
        if (attackTimer <= 0f)
        {
            animator.SetTrigger("Attack");
            // Hit logic via OverlapCircle (instant)
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange, playerLayer);
            foreach (var h in hits)
            {
                h.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            }
            attackTimer = attackCooldown;
        }

        if (player != null && Vector2.Distance(transform.position, player.position) > attackRange + 0.3f)
            state = EnemyState.Chase;
    }

    void MoveTowards(Vector2 targetPos, float spd)
    {
        Vector2 newPos = Vector2.MoveTowards(transform.position, targetPos, spd * Time.deltaTime);
        rb.MovePosition(newPos);
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0) Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
