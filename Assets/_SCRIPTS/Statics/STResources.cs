using UnityEngine;
using System.Collections;

public class STResources : MonoBehaviour
{
    static string _pathOfCubeMaterial = "Materials/Cube/";
    static string _pathOfCubeMaterialSprite = "Materials/Cubeimg/";

    public static Material GetPlayerMaterial(NameOfCubeMaterial name)=> Resources.Load<Material>(_pathOfCubeMaterial + name.ToString());
    public static Sprite GetPlayerMaterialSprite(NameOfCubeMaterial name)=>
        Resources.Load<Sprite>(_pathOfCubeMaterialSprite + KYTGameFree.GetMaterialName( name));



}

