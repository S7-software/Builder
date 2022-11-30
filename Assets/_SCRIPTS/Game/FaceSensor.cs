using UnityEngine;
using System.Collections;

public class FaceSensor : MonoBehaviour
{
    [SerializeField] Cube _mainCube;
    [SerializeField] FaceOfCube _face;
    [SerializeField] BoxCollider _boxCollider;

    private void Start()
    {
        //if (transform.position.y <= 0.1)
        //{
        //    _mainCube.DetectedFace(_face);
        //    Destroy(gameObject, 0.1f);
        //}
        //Kontrol();
        Destroy(gameObject, 0.5f);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerCube"))
        {
            _mainCube.DetectedFace(_face);
        }
    }


    
    public void Kontrol()
    {
    
        Collider[] touchs = Physics.OverlapBox(gameObject.transform.position, Vector3.one / 8f);
        foreach (var item in touchs)
        {
            if (item.gameObject.tag=="PlayerCube")
            {
                Debug.Log("bulundu: " + _face.ToString());
                _mainCube.DetectedFace(_face);
                Destroy(gameObject);
            }
        }
    }



}
