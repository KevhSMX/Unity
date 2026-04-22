using UnityEngine;

public class OutOfMap : MonoBehaviour
{
    public Transform Respawn;
    public ProvaQuadrat scriptVides;
    private bool jaHaChocat = false;

private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player") && !jaHaChocat) // Mirem si el jugador ja a chocat per no fer un doble cop
    {
        jaHaChocat = true;
        scriptVides.vides -= 1; //Treiem una vida

        if (CheckpointManager.tieneCheckpoint) //Si te un checkpoint apareix en ell, si no en el respawn
        {
            other.transform.position = CheckpointManager.posicionGuardada; 
        }
        else
        {
            other.transform.position = Respawn.transform.position;
        }
    }
}

    void OnTriggerExit2D(Collider2D collision) //Per treure el ja a chocat si no esta colisionant ja
    {
        if (collision.CompareTag("Player"))
        {
            jaHaChocat = false;
        }
    }
}

