using UnityEngine;

public class OutOfMap : MonoBehaviour
{
    public Transform Respawn;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = Respawn.transform.position;
        }
    }

}
