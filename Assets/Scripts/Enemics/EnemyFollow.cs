using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float velocitat = 3f;
    public ProvaQuadrat scriptVides; 
    public float tempsInmune = 1.5f;
    private float seguentAtac = 0f;

    void Update()
    {
        // Solo se mueve si el jugador existe
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, velocitat * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Time.time >= seguentAtac)
        {
            scriptVides.vides -= 1;
            seguentAtac = Time.time + tempsInmune;
        }
    }
}