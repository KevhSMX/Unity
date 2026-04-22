using System.Xml.Serialization;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManu : MonoBehaviour
{
    public string SceneName;
    
    public void NextScene() //Tornar al Menu principal
    {
        SceneManager.LoadScene(SceneName);
    }
}
