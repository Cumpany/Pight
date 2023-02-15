using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneButtonScript : MonoBehaviour
{
    public void OpenScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenScene(Scene scene)
    {
        SceneManager.LoadScene(scene.name);
    }
}
