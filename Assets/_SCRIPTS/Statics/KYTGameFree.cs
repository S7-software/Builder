using UnityEngine;
using System.Collections;

public class KYTGameFree : MonoBehaviour
{
    const string GAME_FREE_BEST_HEIGHT = "game free best height";
    const string GAME_FREE_BEST_BLOCKS = "game free best blocks";
    const string GAME_FREE_CHOSEN_MATERIAL = "game free chosen materil";
    const string GAME_FREE_CHOSEN_MATERIAL_NAME_STRING = "game free chosen material name string";


    public static string GetMaterialName(NameOfCubeMaterial name)
    { switch (name)
        {

            case NameOfCubeMaterial.Kutuk: return "Kutuk" ;
            case NameOfCubeMaterial.Agac1:
            case NameOfCubeMaterial.Agac2: return "Agac";
            case NameOfCubeMaterial.Ytong: return "Ytong" ;
            case NameOfCubeMaterial.Tugla: return "Tugla";
            default:
                return "Null";
        }
    }

    public static NameOfCubeMaterial GetChosenMaterial()
    {
        string temp = PlayerPrefs.GetString(GAME_FREE_CHOSEN_MATERIAL);

        switch (temp)
        {

            case "Kutuk": return NameOfCubeMaterial.Kutuk;
            case "Agac2": return NameOfCubeMaterial.Agac2;
            case "Ytong": return NameOfCubeMaterial.Ytong;
            case "Tugla":
            default:
                return NameOfCubeMaterial.Tugla;
            
        }
    }
    public static void SetChosenMaterial(NameOfCubeMaterial mat) { PlayerPrefs.SetString(GAME_FREE_CHOSEN_MATERIAL, mat.ToString()); }

    public static int GetBestHeight()=> PlayerPrefs.GetInt(GAME_FREE_BEST_HEIGHT, 0);
    public static void SetBestHeight(int v)
    {
        int temp = GetBestHeight();
        PlayerPrefs.SetInt(GAME_FREE_BEST_HEIGHT, v > temp ? v : temp);
    }

    public static int GetBestBlocks() => PlayerPrefs.GetInt(GAME_FREE_BEST_BLOCKS, 1);
    public static void SetBestBlocks(int v)
    {
        int temp = GetBestBlocks();
        PlayerPrefs.SetInt(GAME_FREE_BEST_BLOCKS, v > temp ? v : temp);
    }
}
