using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System;

public class CANVAS_UI :MonoBehaviour
{
    [SerializeField] Button _btnPause,_btnTap;
    [SerializeField] TMP_Text _txtBestBlocks, _txtBlocks,_txtBestHeight,_txtHeight;

    int _tempBestHeight, _tempBestBlocks;

    private void Awake()
    {

        SetButtons();
        SetTexts();


    }

    private void SetTexts()
    {
        _tempBestBlocks = KYTGameFree.GetBestBlocks();
        _tempBestHeight = KYTGameFree.GetBestHeight();
        _txtHeight.text = "0";
        _txtBlocks.text = "1";
        SetBestScore(_tempBestBlocks, _tempBestHeight);
    }


    private void SetButtons()
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

    public void SetScore(int currentBlock, int currentHeight)
    {
        _txtBlocks.text = "" + currentBlock;
        _txtHeight.text = "" + currentHeight;

        if (currentHeight > _tempBestHeight)
        {
            _tempBestHeight = currentHeight;
            KYTGameFree.SetBestHeight(_tempBestHeight);
        }
        if (currentBlock > _tempBestBlocks)
        {
            _tempBestBlocks = currentBlock;
            KYTGameFree.SetBestBlocks(_tempBestBlocks);
        }

        SetBestScore(_tempBestBlocks, _tempBestHeight);
    }

    void SetBestScore(int bestBlock,int bestHeight)
    {
        _txtBestBlocks.text = "BEST: " + bestBlock;
        _txtBestHeight.text = "BEST: " + bestHeight;
    }
}
