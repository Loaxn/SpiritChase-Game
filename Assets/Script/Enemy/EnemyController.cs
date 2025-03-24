using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patrolling
    public Transform leftLimit, rightLimit;
    private bool movingRight = true;
    public float moveSpeed = 3f;

    //Detection
    public float sightRange;
    public bool playerInSightRange;

    private void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Check for sight range
        playerInSightRange = Physics2D.OverlapCircle(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange)
            Patrol();
        else
            ChasePlayer();
    }

    private void Patrol()
    {
        if (movingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if (transform.position.x >= rightLimit.position.x)
                movingRight = false;
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if (transform.position.x <= leftLimit.position.x)
                movingRight = true;
        }

        // Flip enemy to face movement direction
        transform.localScale = new Vector3(movingRight ? 1 : -1, 1, 1);
    }

    private void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);

        // Flip enemy towards the player
        if (player.position.x < transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
