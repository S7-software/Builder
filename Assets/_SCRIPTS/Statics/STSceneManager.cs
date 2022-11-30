using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class STSceneManager : MonoBehaviour
{
    public static void GoTo(Scenes scene)
    {
        switch (scene)
        {
            case Scenes.MainMenu:
                SceneManager.LoadScene(Scenes.MainMenu.ToString());
                break;
            case Scenes.Restart:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case Scenes.Quit:
Application.Quit();
                break;
            case Scenes.GameFree:
                SceneManager.LoadScene(Scenes.GameFree.ToString());
                break;
            default:
                break;
        }
    }
}
