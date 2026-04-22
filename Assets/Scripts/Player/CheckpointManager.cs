using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static Vector3 posicionGuardada;
    public static bool tieneCheckpoint = false;

    void Start()
    {
        if (tieneCheckpoint) //Cambiem la posicio de inici si hi ha checkpoint
        {
            transform.position = posicionGuardada;
        }
    }
}
