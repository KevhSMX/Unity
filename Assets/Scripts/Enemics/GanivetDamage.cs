using UnityEngine;

public class GanivetDamage : MonoBehaviour
{
    private ProvaQuadrat scriptVides;
    private bool jaHaChocat = false;


    void Start()
    {
        scriptVides = Object.FindAnyObjectByType<ProvaQuadrat>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !jaHaChocat)
        {
            jaHaChocat = true;
            if (scriptVides != null)
            {
                scriptVides.vides -= 1;
            }
            Destroy(gameObject);
        }
    }
}