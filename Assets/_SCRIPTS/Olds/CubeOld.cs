using UnityEngine;
using System.Collections;

public class CubeOld : MonoBehaviour
{
    [SerializeField] Material[] _colors;
   // [SerializeField] Rigidbody _myRigidbody;
    bool _carpisti = false;
    public int mass;
    private void Awake()
    {
        SetCube();
        
    }
    public void SetCube()
    {
        int random = Random.Range(1, 6);
        mass = random;
       // _myRigidbody.mass = random;
        GetComponent<MeshRenderer>().material = _colors[random-1];
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (_carpisti) return;
        if (collision.gameObject.tag == "Player")
        {
_carpisti = true;
        gameObject.transform.SetParent(collision.transform);
            //_myRigidbody.isKinematic = true;
            //_myRigidbody.useGravity = false;
        }
        
    }
}
