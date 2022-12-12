using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnMenuChanger : MonoBehaviour
{
    public NameOfCubeMaterial _currentMaterialName;
    [SerializeField] Image _imgMaterial,_imgBG;


    public void SetButton(NameOfCubeMaterial name)
    {

    }

    public void EvetnMainIn()
    {
        GameManager.instantiate.SetTempChosenMaterial(_currentMaterialName);
    }
    public void EvetnMainOut()
    {
        FindObjectOfType<CANVAS_CHANGE_CUBE>().EventMenuOut();
    }
    public void EvetnMainUp()
    {
        FindObjectOfType<CANVAS_CHANGE_CUBE>().SetChanged(false);
        FindObjectOfType<CANVAS_CHANGE_CUBE>().EventMenuOut();
    }

}
