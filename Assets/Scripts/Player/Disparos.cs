using UnityEngine;

public class Disparos : MonoBehaviour
{
    public GameObject bolaPrefab; 
    public float velocidadBala = 15f;
    public float delayDisparo = 0.7f;
    
    private float tiempoSiguiente; //Cooldown

    void Update()
    {
        if (Time.time < tiempoSiguiente) return; //Mirem si el temps entre bala i bala a pasat o no.

// Segons la fletxa que presionem dispara a una o un altre direcció.
        if (Input.GetKey(KeyCode.UpArrow))    Disparar(Vector2.up);
        else if (Input.GetKey(KeyCode.DownArrow))  Disparar(Vector2.down);
        else if (Input.GetKey(KeyCode.LeftArrow))  Disparar(Vector2.left);
        else if (Input.GetKey(KeyCode.RightArrow)) Disparar(Vector2.right);
    }

    void Disparar(Vector2 direccion)
    {
        tiempoSiguiente = Time.time + delayDisparo; //Actualitzem el temps.
        GameObject bola = Instantiate(bolaPrefab, transform.position, Quaternion.identity); //Instlanciem la bala
        
        Rigidbody2D rb = bola.GetComponent<Rigidbody2D>(); //Accedim al motor de fisicas.
        
        if (rb != null)
        {
            //Li donem veolidad lineal a la direcció anteriorment recollida
            rb.linearVelocity = direccion * velocidadBala;
        }

        Destroy(bola, 2f); // La bala es destrueix si han pasat 2s
    }
}

