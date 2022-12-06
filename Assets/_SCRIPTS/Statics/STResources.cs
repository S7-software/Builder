using UnityEngine;
using System.Collections;

public class STResources : MonoBehaviour
{
    static string _pathOfCubeMaterial = "Materials/Cube/";

	public static Material GetPlayerMaterial(NameOfCubeMaterial name)=> Resources.Load<Material>(_pathOfCubeMaterial + name.ToString());


	
}

