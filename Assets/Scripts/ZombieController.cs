using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public int puntosVida = 1;

    private Rigidbody2D rb;
    private Transform objetivo; // El jugador

    public float velocidad = 1.5f;         // Velocidad de movimiento
    public float distanciaMinima = 0.5f;   // No se acerca más de esta distancia

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        objetivo = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (objetivo == null)
        {
            Debug.LogError("No se encontró ningún objeto con el tag 'Player'");
        }
    }

    void FixedUpdate()
    {
        if (objetivo != null)
        {
            float distancia = Vector2.Distance(transform.position, objetivo.position);

            if (distancia > distanciaMinima)
            {
                Vector2 direccion = (objetivo.position - transform.position).normalized;
                rb.linearVelocity = direccion * velocidad;
            }
            else
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
    }
}
