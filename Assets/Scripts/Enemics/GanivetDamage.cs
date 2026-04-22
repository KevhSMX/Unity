using UnityEngine;

public class GanivetDamage : MonoBehaviour
{
    private ProvaQuadrat scriptVides;
    private bool jaHaChocat = false;


    void Start()
    {
        scriptVides = Object.FindAnyObjectByType<ProvaQuadrat>(); //Busquem al jugador
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !jaHaChocat) // Si no a chocat ja i es un jugador treiem una vida.
        {
            jaHaChocat = true;
            if (scriptVides != null)
            {
                scriptVides.vides -= 1;
            }
            Destroy(gameObject); //Adeu
        }
    }
}
