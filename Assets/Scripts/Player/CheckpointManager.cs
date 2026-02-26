using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static Vector3 posicionGuardada;
    public static bool tieneCheckpoint = false;

    void Start()
    {
        if (tieneCheckpoint)
        {
            transform.position = posicionGuardada;
        }
    }
}