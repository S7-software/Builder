using UnityEngine;
using System.Collections;

public class STCube : MonoBehaviour
{
    
   public static Vector3 GetSpawnLocalPosFromFace(FaceOfCube face)
    {
        switch (face)
        {
            case FaceOfCube.Top:
                return new Vector3(0, 1, 0); 
            case FaceOfCube.Bottom:
                return new Vector3(0, -1, 0);
            case FaceOfCube.Left:
                return new Vector3(-1, 0, 0);
            case FaceOfCube.Right:
                return new Vector3(1, 0, 0);
            case FaceOfCube.Front:
                return new Vector3(0, 0, -1);

            case FaceOfCube.Back:
                return new Vector3(0, 0, 1);
            default:
                return new Vector3(0, 0, 0);
        }
    }
}
