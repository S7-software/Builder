using UnityEngine;
using System.Collections;

public class KYTGameFree : MonoBehaviour
{
    const string GAME_FREE_BEST_HEIGHT = "game free best height";
    const string GAME_FREE_BEST_BLOCKS = "game free best blocks";

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
