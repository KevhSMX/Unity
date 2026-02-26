using System.Xml.Serialization;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsButton : MonoBehaviour
{
    public string SceneName;
    
    public void NextScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}

