using UnityEngine;
using System.Collections;

public class FaceAnimCube : MonoBehaviour
{
    [SerializeField] MeshRenderer _meshRenderer;

    public void SetMaterial(Material material) { _meshRenderer.material = material; }
}
