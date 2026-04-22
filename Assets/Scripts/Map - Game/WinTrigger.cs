using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    public string nombreEscena;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //Si toquem aquest objecte cambiem d'escena a la de victoria.
        {
            SceneManager.LoadScene(nombreEscena);
        }
    }
}
