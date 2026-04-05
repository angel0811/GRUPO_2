using UnityEngine;
public class enemycontrolle : MonoBehaviour
{
    public Transform player;         // Arrastra al jugador aquí en el Inspector
    public float detectionRadius = 5f;
    public float speed = 2f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRadius)
        {
            Vector2 direction = (player.position - transform.position).normalized;
           
            movement = new Vector2(direction.x, 0);
        }
        else
        {
            movement = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

   
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}