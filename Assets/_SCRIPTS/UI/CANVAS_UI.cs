using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CANVAS_UI :MonoBehaviour
{
    [SerializeField] Button _btnRestart,_btnExit;

    private void Awake()
    {
        _btnRestart.onClick.AddListener(() =>
        {
            STSceneManager.GoTo(Scenes.Restart);
        });

_btnExit.onClick.AddListener(() =>
        {
            STSceneManager.GoTo(Scenes.Quit);
        });

    }
}
