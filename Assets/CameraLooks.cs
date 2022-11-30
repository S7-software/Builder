using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraLooks : MonoBehaviour
{
    [SerializeField] [Range(1f, 100f)] float _speed;
    Tween _tween;
    bool _isTurning = false;
    public void StartRotate()
    {
      _tween=  transform.DORotate(new Vector3(0,180, 0), _speed).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        _isTurning = true;
    }
    public void StopRotate()
    {
       
        _tween.Kill();
        
        _isTurning = false;

    }
    public void SetLookRange(float add)
    {
        Transform tempTra = transform.GetChild(0);
        Vector3 temp = new Vector3(tempTra.localPosition.x, tempTra.localPosition.y + add, tempTra.localPosition.z - add);
        tempTra.DOLocalMove(temp, 3f).SetEase(Ease.OutQuad);
    }


    
    //PARAMETERS
    public bool IsTurning() => _isTurning;

}
