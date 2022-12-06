using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class CANVAS_GAME_OVER_FREE : MonoBehaviour
{
    [SerializeField] float _delay = 0.2f;
    [SerializeField] Button _btnContiune, _btnRestart, _btnMainMenu;

    private void Awake()
    {
        _btnContiune.onClick.AddListener(() =>
        {
            StartCoroutine(CorContiuine());
        });
        _btnRestart.onClick.AddListener(() =>
        {
            StartCoroutine(GoToScene(Scenes.Restart));

        });
        _btnMainMenu.onClick.AddListener(() =>
        {
            StartCoroutine(GoToScene(Scenes.MainMenu));

        });

    }
    IEnumerator GoToScene(Scenes scene)
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.clickUI);
        DOTween.KillAll();
        yield return new WaitForSeconds(_delay);
        STSceneManager.GoTo(scene);
    }

    IEnumerator CorContiuine ()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.clickUI);
        GameManager.instantiate.ButtonContiune();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
       
    }
}
