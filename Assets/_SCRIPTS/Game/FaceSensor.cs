using UnityEngine;
using System.Collections;

public class FaceSensor : MonoBehaviour
{
    [SerializeField] Cube _mainCube;
    [SerializeField] FaceOfCube _face;
    [SerializeField] BoxCollider _boxCollider;

    
    private void Start()
    {
        
        Destroy(gameObject, 0.5f);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagsOfGO.PlayerCube.ToString()))
        {
            _mainCube.DetectedFace(_face);
        }
    }





}
