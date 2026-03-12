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
        // 1. Calculamos la distancia
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // 2. Si está cerca, calculamos dirección
        if (distanceToPlayer < detectionRadius)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            // Solo nos movemos en X
            movement = new Vector2(direction.x, 0);
        }
        else
        {
            // Si no está cerca, se queda quieto
            movement = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        // 3. Aplicamos el movimiento (Aquí es donde suele faltar el paréntesis)
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    // Esto es para que puedas ver el radio de detección en la escena
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}