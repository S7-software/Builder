using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CANVAS_MAIN_MENU : MonoBehaviour
{
    [SerializeField] float _delay = 0.3f;
    [SerializeField] Button _btnFreeBuild, _btnArcade, _btnCustomize, _btnSettigns, _btnExit;

    private void Awake()
    {
        ButtonHandles();
    }

    private void ButtonHandles()
    {
        _btnFreeBuild.onClick.AddListener(() => { StartCoroutine(GoToScene(Scenes.GameFree)); });
        _btnArcade.onClick.AddListener(() => { StartCoroutine(GoToScene(Scenes.GameFree)); });
        _btnCustomize.onClick.AddListener(() => { StartCoroutine(GoToScene(Scenes.GameFree)); });
        _btnSettigns.onClick.AddListener(() => { StartCoroutine(GoToScene(Scenes.GameFree)); });
        _btnExit.onClick.AddListener(() => { StartCoroutine(GoToScene(Scenes.Quit)); });
    }

    IEnumerator GoToScene(Scenes scene)
    {
        yield return new WaitForSeconds(_delay);
        STSceneManager.GoTo(scene);
    }
}
