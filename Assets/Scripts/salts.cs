using UnityEngine;


public class salts : MonoBehaviour
{
    public ProvaQuadrat jugador; //Reservem un nom per el script principal per aixi poder refereniarlo despres.

    void Start()
    {
        jugador = GetComponentInParent<ProvaQuadrat>(); //Al començar el script busquem en els components pares el script ProvaQuadrat per asignarlo en la vairiable jugador.
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Terra") //Aquesta colisio toca el terra canviarem la variable bool del script ProvaQuadrat que comproba si toquem el terra a True.
        {
            jugador.terraCheck = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) //Aquesta colisio toca el terra canviarem la variable bool del script ProvaQuadrat que comproba si toquem el terra a True.
    {
       jugador.terraCheck = false; 
    }

}
