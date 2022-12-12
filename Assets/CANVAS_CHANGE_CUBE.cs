using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class CANVAS_CHANGE_CUBE : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 2f)] float _durationMenu=0.2f;
    [SerializeField] Transform _trfMenu,_trfIcon;
    [SerializeField] Image _imgChosen;
    [SerializeField] TMP_Text _txtChosen;
    [SerializeField] Button _btnGeri;

    NameOfCubeMaterial _current,_chosen;

    bool _isChanged = false;

    float _localXIcon;
    Tween _tween1, _tween2;
    private void Awake()
    {
        _btnGeri.gameObject.SetActive(false);
    }
    private void Start()
    {_localXIcon = _trfIcon.localPosition.x;
        _current = GameManager.instantiate.GetChozenNameOfCubeMaterial();
    }


    public void EventIconGiris()
    {
        _btnGeri.gameObject.SetActive(true);


        _trfMenu.DOLocalMove(Vector3.zero, _durationMenu).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            
        });
        _trfIcon.DOLocalMoveX(2000, _durationMenu).SetEase(Ease.InOutSine);
    }

    public void EventMenuOut()
    {
        if (_isChanged) return;
       _tween1= _trfIcon.DOLocalMoveX(_localXIcon, _durationMenu).SetEase(Ease.InOutSine);
       _tween2= _trfMenu.DOLocalMoveX(2000f, _durationMenu).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            GameManager.instantiate.SetChosenMaterial();
            _btnGeri.gameObject.SetActive(false);

        });
    }

    public void SetChanged(bool v) { _isChanged = v;
        _tween1.Kill();
        _tween2.Kill();

    }
    public void SetChosenView(Sprite sprite,string txtHeader,bool buying,int price)
    {
        _imgChosen.sprite = sprite;
        _txtChosen.text = txtHeader;
        if (buying)
        {
            //
        }
        else
        {
            //
        }
    }
}
