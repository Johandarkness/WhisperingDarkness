using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para usar SceneManager

public class SceneChanger : MonoBehaviour
{
    // Cambiar escena por nombre
    public void ChangeSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Cambiar escena por índice
    public void ChangeSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

