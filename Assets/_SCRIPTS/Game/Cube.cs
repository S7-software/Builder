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
    private void Awake()
    {
        _ownLoc = transform.position;
        HideAllFaceObj();
        if (transform.position.y <= 0.1) DetectedFace(FaceOfCube.Bottom);
      


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
        //Vector3 temp;
        //_ownLoc = transform.position;
        //temp = GetSpawnFromFace(_selectedFace);
        //return  temp;
        return STCube.GetSpawnLocalPosFromFace(_selectedFace);
    }

  

    Vector3 GetSpawnFromFace(FaceOfCube face)
    {
        
        switch (face)
        {
            case FaceOfCube.Top:
                return _objTop.transform.position;
            case FaceOfCube.Bottom:
                return _objBottom.transform.position;
            case FaceOfCube.Left:
                return _objLeft.transform.position;
            case FaceOfCube.Right:
                return _objRight.transform.position;
            case FaceOfCube.Front:
                return _objFront.transform.position;

            case FaceOfCube.Back:
                return _objBack.transform.position;
            default:
                return new Vector3(0, 0, 0);
        }
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

    //void DetectedFace()
    //{
    //    int run1 = 0, run2 = 0;
    //    List<FaceOfCube> temp = new List<FaceOfCube>(_nullFaces);
    //    foreach (var item in temp)
    //    {
    //        Debug.Log("Foreach1: " + run1);
    //        Vector3 temp2 = _ownLoc + GetSpawnFromFace(item);
    //        Collider[] touchs = Physics.OverlapBox(temp, Vector3.one / 8f);
    //        foreach (var item2 in touchs)
    //        {
    //            Debug.Log("Foreach2: " + run2);

    //            if (item2.gameObject.tag == "PlayerCube")
    //            {
    //                Debug.Log("bulundu: " + item.ToString());
    //            DetectedFace(item);
    //            }
                
    //        }
    //    }

        
        
    //}





}
