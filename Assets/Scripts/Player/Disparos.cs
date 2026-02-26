using UnityEngine;

public class Disparos : MonoBehaviour
{
    public GameObject bolaPrefab;
    public float velocidadBala = 15f;
    public float delayDisparo = 0.7f;
    private float tiempoSiguiente;

    void Update()
    {
        if (Time.time < tiempoSiguiente) return;

        if (Input.GetKey(KeyCode.UpArrow))    Disparar(Vector2.up);
        else if (Input.GetKey(KeyCode.DownArrow))  Disparar(Vector2.down);
        else if (Input.GetKey(KeyCode.LeftArrow))  Disparar(Vector2.left);
        else if (Input.GetKey(KeyCode.RightArrow)) Disparar(Vector2.right);
    }

    void Disparar(Vector2 direccion)
    {
        tiempoSiguiente = Time.time + delayDisparo;
        GameObject bola = Instantiate(bolaPrefab, transform.position, Quaternion.identity);
        
        Rigidbody2D rb = bola.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direccion * velocidadBala;
        }

        Destroy(bola, 2f);
    }
}

