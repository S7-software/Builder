using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instantiate;
    [SerializeField] GameObject _cloneCube, _structure;
    [SerializeField] [Range(0.1f, 3f)] float _speedAnimChange = 0.5f;
    [SerializeField] [Range(3, 10)] int _countBombDestroy = 8;
    [SerializeField] [Range(1f, 10f)] float _timeBombEfect = 3f;




    Cube _cubeLast;
    List<Cube> _allCubesInScene = new List<Cube>();
    bool _showAnimOfCube = false;
    Rigidbody _rigiStructure;
    float _counterAnimChange = 0;
    private void Awake()
    {
        instantiate = this;
        _cubeLast = FindObjectOfType<Cube>();
       // _cubeLast.DetectedFace(FaceOfCube.Bottom);
        _allCubesInScene.Add(_cubeLast);
        _rigiStructure = _structure.GetComponent<Rigidbody>();

    }
    private void Start()
    {
        _rigiStructure.useGravity = true;
        _rigiStructure.isKinematic = false;
        _showAnimOfCube = true;
        _cubeLast.RandomShowFace();
    }

    private void Update()
    {
        AnimOfCubesFace();
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

    public void ChangeActiveCube(Cube cube)
    {
        _showAnimOfCube = false;
        _cubeLast.HideAllFaceObj();
        _cubeLast = cube;
        _showAnimOfCube = true;
    }




    public void ButtonTap()
    {
        _rigiStructure.useGravity = false;
        _showAnimOfCube = false;
        _cubeLast.HideAllFaceObj();

        Vector3 locPos = _cubeLast.GetSpawnFromSelectedFace();
        GameObject go = Instantiate(_cloneCube,  _cubeLast.transform);
        go.transform.localPosition = locPos;
        go.transform.localRotation = Quaternion.Euler(0, 0, 0);
      
        _cubeLast = go.GetComponent<Cube>();
        _allCubesInScene.Add(_cubeLast);
        _rigiStructure.useGravity = true;
        _counterAnimChange = 0;
        _showAnimOfCube = true;
    }
    void AnimOfCubesFace()
    {
        if (!_showAnimOfCube) return;
        _counterAnimChange += Time.deltaTime;
        if (_counterAnimChange < _speedAnimChange) return;
        _showAnimOfCube = false;
        _counterAnimChange = 0;
        _cubeLast.RandomShowFace();
        _showAnimOfCube = true;




    }

}
