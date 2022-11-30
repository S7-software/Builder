using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CANVAS_UI :MonoBehaviour
{
    [SerializeField] Button _btnPause,_btnTap;

    private void Awake()
    {
        _btnPause.onClick.AddListener(() =>
        {
            SetActivePauseButton(false);
            GameManager.instantiate.ButtonPause();
        });

        _btnTap.onClick.AddListener(() =>
        {
            GameManager.instantiate.ButtonTap();
        });

    }

    public void SetActivePauseButton(bool deger)
    {
        _btnPause.gameObject.SetActive(deger);
    }
}
