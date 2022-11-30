using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CANVAS_BACKGROUND : MonoBehaviour
{
    public UnityEngine.UI.RawImage img;

    private Texture2D backgroundTexture;
    public Color _color1, _color2;

    void Awake()
    {
        img.color=Color.white;
        backgroundTexture = new Texture2D(1, 2);
        backgroundTexture.wrapMode = TextureWrapMode.Clamp;
        backgroundTexture.filterMode = FilterMode.Bilinear;
        SetColor(_color1, _color2);
    }

    public void SetColor(Color color1, Color color2)
    {
        backgroundTexture.SetPixels(new Color[] { color1, color2 });
        backgroundTexture.Apply();
        img.texture = backgroundTexture;
    }
}
