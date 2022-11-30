using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] GameObject _objTop, _objBottom, _objLeft, _objRight, _objFront, _objBack;
    [SerializeField] GameObject[] _sensors;

    Vector3 _ownLoc;
   public List<FaceOfCube> _nullFaces = new List<FaceOfCube> {
        FaceOfCube.Top, FaceOfCube.Bottom, FaceOfCube.Left, FaceOfCube.Right, FaceOfCube.Front, FaceOfCube.Back };
    FaceOfCube _selectedFace;
    bool _faceWorked = false;
    private void Awake()
    {
        _ownLoc = transform.position;
        HideAllFaceObj();
      


    }
    private void Start()
    {
        StartCoroutine(FirstStart());

    }
    IEnumerator FirstStart()
    {
        ActiveSensors();
        yield return new WaitForSeconds(0.2f);
        _selectedFace = GetRandomNullFace();
    }

    public void DetectedFace(FaceOfCube face) { _nullFaces.Remove(face); }
    public void HideAllFaceObj() {
        _objTop.SetActive(false);
        _objBottom.SetActive(false);
        _objLeft.SetActive(false);
        _objRight.SetActive(false);
        _objFront.SetActive(false);
        _objBack.SetActive(false);
    }
     FaceOfCube GetRandomNullFace() {
        //0 alan kaldığında
        return _nullFaces[Random.Range(0, _nullFaces.Count)];
    }
    FaceOfCube GetRandomNullFaceWithoutThisFace(FaceOfCube faceOfCube)
    {
        if (_nullFaces.Count == 1) return faceOfCube;
        _nullFaces.Remove(faceOfCube);
        FaceOfCube temp = GetRandomNullFace();
        _nullFaces.Add(faceOfCube);
        return temp;
    }
    public void RandomShowFace()
    {
        HideAllFaceObj();
        FaceOfCube face = GetRandomNullFaceWithoutThisFace(_selectedFace);
        _selectedFace = face;
        _faceWorked = true;
        switch (face)
        {
            case FaceOfCube.Top:
                _objTop.SetActive(true);
                break;
            case FaceOfCube.Bottom:
                _objBottom.SetActive(true);
                break;
            case FaceOfCube.Left:
                _objLeft.SetActive(true);
                break;
            case FaceOfCube.Right:
                _objRight.SetActive(true);
                break;
            case FaceOfCube.Front:
                _objFront.SetActive(true);
                break;
            case FaceOfCube.Back:
                _objBack.SetActive(true);
                break;
            default:
                break;
        }
    }

    public Vector3 GetSpawnFromSelectedFace()
    {
       
        return STCube.GetSpawnLocalPosFromFace(_selectedFace);
    }



   void ActiveSensors()
    {
        foreach (var item in _sensors)
        {
            item.SetActive(true); 
        }
    }
    public void DestroyWithBomb(float countDown)
    {

        Destroy(gameObject, countDown);
    }

    public bool IsFaceWorked() => _faceWorked;





}
