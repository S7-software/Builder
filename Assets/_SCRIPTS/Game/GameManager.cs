using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instantiate;
    [SerializeField] GameObject _cloneCube, _structure,_canvasPause,_canvasGameOverFree;
    [SerializeField] [Range(0.1f, 3f)] float _speedAnimChange = 0.5f;
    [SerializeField] [Range(3, 10)] int _countBombDestroy = 8;
    [SerializeField] [Range(1f, 10f)] float _timeBombEfect = 3f;

    [Header("-------------")]
    [SerializeField] NameOfCubeMaterial[] _namesOfCubeMat;
    NameOfCubeMaterial _chosenNameOfCubeMat;
    Cube _cubeLast;
    List<Cube> _allCubesInScene = new List<Cube>();
    bool _showAnimOfCube = false;

    

    Rigidbody _rigiStructure;
    float _counterAnimChange = 0;
    int _heightMax = 0, _counterCamera = 11;
    CANVAS_UI _canvasUI;
    Material _chosenMat;
    private void Awake()
    {
        instantiate = this;
        _cubeLast = FindObjectOfType<Cube>();
        _canvasUI = FindObjectOfType<CANVAS_UI>();
        _allCubesInScene.Add(_cubeLast);
        _rigiStructure = _structure.GetComponent<Rigidbody>();
        _chosenNameOfCubeMat = _namesOfCubeMat[0];
        _chosenMat = STResources.GetPlayerMaterial(_chosenNameOfCubeMat);

    }

   

    private void Start()
    {
       
        StartCoroutine(StartCor());
        UpdateScore();
    }

    IEnumerator StartCor()
    {
        _rigiStructure.useGravity = true;
        _rigiStructure.isKinematic = false;
        _showAnimOfCube = true;
        _cubeLast.RandomShowFace();
        FindObjectOfType<CameraLooks>().StartRotate();
        yield return new WaitForSeconds(0);

    }

    private void Update()
    {
        AnimOfCubesFace();
    }




    //CUBE
    public void ChangeActiveCube(Cube cube)
    {
        _showAnimOfCube = false;
        _cubeLast.HideAllFaceObj();
        _cubeLast = cube;
        _showAnimOfCube = true;
    }
    void AnimOfCubesFace()
    {
        if (!_showAnimOfCube) return;
        _counterAnimChange += Time.deltaTime;
        if (_counterAnimChange < GetSpeedAnimChange()) return;
        _showAnimOfCube = false;
        _counterAnimChange = 0;
        _cubeLast.RandomShowFace();
        _showAnimOfCube = true;




    }


    //BUTTON HANDLES
    public void ButtonTap()
    {
        if (!_cubeLast.IsFaceWorked()) return;
        SoundBox.instance.PlayOneShot(NamesOfSound.craft);
        _rigiStructure.useGravity = false;
        _showAnimOfCube = false;
        _cubeLast.HideAllFaceObj();

        Vector3 locPos =  _cubeLast.GetSpawnFromSelectedFace();
        GameObject go = Instantiate(_cloneCube, _cubeLast.transform);
        _cubeLast = go.GetComponent<Cube>();

       // _chosenMat = STResources.GetPlayerMaterial(_chosenNameOfCubeMat);
        _cubeLast.SetParameters(locPos,_chosenMat);

        _allCubesInScene.Add(_cubeLast);
        _rigiStructure.useGravity = true;
        _counterAnimChange = GetSpeedAnimChange() - 0.4f;
        _showAnimOfCube = true;

        UpdateScore();

    }

    

    public void ButtonBomb()
    {
        int tempL = _countBombDestroy;
        _showAnimOfCube = false;
        _cubeLast.HideAllFaceObj();
        for (int i = _allCubesInScene.Count - 1; i >= 1; i--)
        {
            Cube tempCube = _allCubesInScene[i];
            tempCube.DestroyWithBomb(_timeBombEfect);
            _allCubesInScene.Remove(tempCube);
            if (tempL == 0) break;
            tempL--;
        }
        _cubeLast = _allCubesInScene[_allCubesInScene.Count - 1];

    }

    public void ButtonPause()
    {
        Instantiate(_canvasPause);
    }

    public void ButtonContiune()
    {

        SetActiveBtnPause(true);
       ///// yapılacaklar
    }

    // PARAMETERS
    public void SetActiveBtnPause(bool v)
    {
        _canvasUI.SetActivePauseButton(v);
    }

    private void UpdateScore()
    {
        int height = Convert.ToInt32(Math.Round(_cubeLast.gameObject.transform.position.y));
        _heightMax = height > _heightMax ? height : _heightMax;
        _canvasUI.SetScore(_allCubesInScene.Count, _heightMax);
        UpdateCameraDistance(_heightMax);
    }

    private void UpdateCameraDistance(int v)
    {
        if (v == _counterCamera)
        {
            SoundBox.instance.PlayOneShot(NamesOfSound.cameradistance);
            _counterCamera += 8;
            FindObjectOfType<CameraLooks>().SetLookRange(8);
        }
    }
    float GetSpeedAnimChange() {
        float temp= _speedAnimChange * ((50 - ((_heightMax > 0) ? (float)_heightMax : 1)) / 50);
        return temp < 0.4f ? 0.4f : temp;
    }
    public NameOfCubeMaterial GetChozenNameOfCubeMaterial() => _chosenNameOfCubeMat;


    // STATES OF GAME

    public void Finish()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.fail3);
        SetActiveBtnPause(false);
        _showAnimOfCube = false;
        _cubeLast.HideAllFaceObj();
        Instantiate(_canvasGameOverFree);
    }


}
