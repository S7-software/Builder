using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CANVAS_CHANGE_CUBE : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 2f)] float _durationMenu=0.2f;
    [SerializeField] Transform _trfMenu,_trfIcon;
    [SerializeField] Image _imgChosen;
    
    NameOfCubeMaterial _current,_chosen;

    bool _isActiveMenu = false;

    float _localXIcon;
    private void Awake()
    {
        
    }
    private void Start()
    {_localXIcon = _trfIcon.localPosition.x;
        _current = GameManager.instantiate.GetChozenNameOfCubeMaterial();
    }


    public void EventIconGiris()
    {
        _imgChosen.color = Color.red;
        _trfMenu.DOLocalMove(Vector3.zero, _durationMenu).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            _isActiveMenu = true;
        });
        _trfIcon.DOLocalMoveX(2000, _durationMenu).SetEase(Ease.InOutSine);
    }

    public void EventMenuOut()
    {
        _trfIcon.DOLocalMoveX(_localXIcon, _durationMenu).SetEase(Ease.InOutSine);
        _trfMenu.DOLocalMoveX(2000f, _durationMenu).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            _isActiveMenu = false;
        });
    }
}
