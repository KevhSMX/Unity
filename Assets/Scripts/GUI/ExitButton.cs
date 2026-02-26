using System.Xml.Serialization;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    private int clicks = 0;
    private RectTransform rect;
    private Vector2 posInicial = new Vector2(33f, -107f); // Tu posición original

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    public void QuitGame()
    {
        clicks++;

        if (clicks == 1)
        {
            rect.anchoredPosition = new Vector2(150f, 50f); 
        }
        else if (clicks == 2)
        {
            rect.anchoredPosition = new Vector2(-150f, 50f);
        }
        else
        {
            rect.anchoredPosition = posInicial;
            
            Application.Quit();
            
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}