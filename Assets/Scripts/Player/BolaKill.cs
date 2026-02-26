using UnityEngine;

public class BolaKill : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // El tag "Enemic" es correcto según tu imagen
        if (other.CompareTag("Enemic"))
        {
            Destroy(other.gameObject); // Borra al enemigo
            Destroy(gameObject);       // Borra la bola
        }
    }
}