using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class CANVAS_PAUSE : MonoBehaviour
{
    [SerializeField] float _delay = 0.1f;
    [SerializeField] Button _btnContiune, _btnMainMenu;

    private void Awake()
    {
        _btnMainMenu.onClick.AddListener(() =>
        {
            SoundBox.instance.PlayOneShot(NamesOfSound.clickUI);
            DOTween.KillAll();
            Invoke(nameof(MainMenu), _delay);
        });
        _btnContiune.onClick.AddListener(() =>
        {
            SoundBox.instance.PlayOneShot(NamesOfSound.clickUI);
            GameManager.instantiate.SetActiveBtnPause(true);
            Destroy(gameObject, _delay);
        });
    }

    void MainMenu()
    {
        STSceneManager.GoTo(Scenes.MainMenu);
    }
}
