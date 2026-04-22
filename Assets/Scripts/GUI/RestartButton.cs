using System.Xml.Serialization;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public string SceneName;
    
    public void NextScene()
    {
        SceneManager.LoadScene(SceneName); //Tornem a jugar
    }
}
