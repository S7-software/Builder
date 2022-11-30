using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class STSceneManager : MonoBehaviour
{
    public static void GoTo(Scenes scene)
    {
        switch (scene)
        {
            case Scenes.Main:
                break;
            case Scenes.Restart:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case Scenes.Quit:
Application.Quit();
                break;
            default:
                break;
        }
    }
}
