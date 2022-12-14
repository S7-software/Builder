using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnMenuChanger : MonoBehaviour
{
    public NameOfCubeMaterial _currentMaterialName;
    [SerializeField] Image _imgMaterial,_imgBG;
    [SerializeField] Color _colorChosen,_colurNotChosen;

    private void Awake()
    {
        SetImageMaterial(_currentMaterialName);

    }
   
    public void SetButton(NameOfCubeMaterial name,bool isChosen)
    {
        SetBackgroundColor(isChosen);
        SetImageMaterial(name);
    }

    public void SetBackgroundColor(bool isChosen)
    {
        _imgBG.color = isChosen ? _colorChosen : _colurNotChosen;
    }
    public void SetImageMaterial(NameOfCubeMaterial name)
    {
        _imgMaterial.sprite = STResources.GetPlayerMaterialSprite(name);

    }

    public void EvetnMainIn()
    {
        CANVAS_CHANGE_CUBE.instantiate.SetChanged(true);
        GameManager.instantiate.SetTempChosenMaterial(_currentMaterialName);
        CANVAS_CHANGE_CUBE.instantiate.SetAllBtnMenuChangerAsChosen(false);
        SetBackgroundColor(true);
    }
    public void EvetnMainOut()
    {
        FindObjectOfType<CANVAS_CHANGE_CUBE>().SetChanged(false);
        FindObjectOfType<CANVAS_CHANGE_CUBE>().EventMenuOut();
    }
  

}
