using System.Xml.Serialization;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public string SceneName;
    
    public void NextScene() //Començcar el joc
    {
        CheckpointManager.tieneCheckpoint = false;
        SceneManager.LoadScene(SceneName);
    }
}
