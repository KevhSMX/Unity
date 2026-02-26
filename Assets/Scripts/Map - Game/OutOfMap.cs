using UnityEngine;

public class OutOfMap : MonoBehaviour
{
    public Transform Respawn;
    public ProvaQuadrat scriptVides;
    private bool jaHaChocat = false;

private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player") && !jaHaChocat)
    {
        jaHaChocat = true;
        scriptVides.vides -= 1;

        if (CheckpointManager.tieneCheckpoint)
        {
            other.transform.position = CheckpointManager.posicionGuardada;
        }
        else
        {
            other.transform.position = Respawn.transform.position;
        }
    }
}

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jaHaChocat = false;
        }
    }
}

