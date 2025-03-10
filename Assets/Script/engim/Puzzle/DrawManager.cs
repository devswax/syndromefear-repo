using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DrawManager : MonoBehaviour
{
    public Texture2D drawTexture;
    private Color penColor = Color.black;
    private int penSize = 2;
    private RawImage rawImage;
    private RectTransform rectTransform;

    private Vector2 lastDrawPoint = Vector2.zero;
    private bool isDrawing = false;

    void Start()
    {
        rawImage = GetComponent<RawImage>();
        rectTransform = rawImage.rectTransform;

        drawTexture = new Texture2D(512, 512);
        Color fillColor = Color.white;
        Color[] pixels = drawTexture.GetPixels();
        for (int i = 0; i < pixels.Length; i++)
            pixels[i] = fillColor;
        drawTexture.SetPixels(pixels);
        drawTexture.Apply();

        rawImage.texture = drawTexture;
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            Vector2 localPoint;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, null, out localPoint))
            {
                Vector2Int pixelUV = new Vector2Int(
                    (int)(((localPoint.x + rectTransform.rect.width / 2) / rectTransform.rect.width) * drawTexture.width),
                    (int)(((localPoint.y + rectTransform.rect.height / 2) / rectTransform.rect.height) * drawTexture.height)
                );

                if (isDrawing)
                {
                    DrawLine(ToVector2Int(lastDrawPoint), pixelUV); // Conversion explicite
                }
                lastDrawPoint = pixelUV;
                isDrawing = true;
            }
        }
        else
        {
            isDrawing = false;
        }
    }

    void DrawLine(Vector2Int start, Vector2Int end)
    {
        int dx = Mathf.Abs(end.x - start.x);
        int dy = Mathf.Abs(end.y - start.y);
        int sx = start.x < end.x ? 1 : -1;
        int sy = start.y < end.y ? 1 : -1;
        int err = dx - dy;

        while (true)
        {
            SetPixelOnLine(start.x, start.y);
            if (start.x == end.x && start.y == end.y) break;
            int e2 = err * 2;
            if (e2 > -dy)
            {
                err -= dy;
                start.x += sx;
            }
            if (e2 < dx)
            {
                err += dx;
                start.y += sy;
            }
        }
    }

    void SetPixelOnLine(int x, int y)
    {
        for (int i = -penSize; i < penSize; i++)
        {
            for (int j = -penSize; j < penSize; j++)
            {
                if (x + i >= 0 && x + i < drawTexture.width && y + j >= 0 && y + j < drawTexture.height)
                {
                    drawTexture.SetPixel(x + i, y + j, penColor);
                }
            }
        }
        drawTexture.Apply();
    }

    public void ClearScreen()
    {
        Color[] pixels = drawTexture.GetPixels();
        for (int i = 0; i < pixels.Length; i++)
            pixels[i] = Color.white;
        drawTexture.SetPixels(pixels);
        drawTexture.Apply();
    }

    public void SaveDrawing()
    {
        byte[] textureData = drawTexture.EncodeToPNG();
        PlayerPrefs.SetString("SavedNotes", System.Convert.ToBase64String(textureData));
        PlayerPrefs.Save();
    }

    public void LoadDrawing()
    {
        if (PlayerPrefs.HasKey("SavedNotes"))
        {
            byte[] textureData = System.Convert.FromBase64String(PlayerPrefs.GetString("SavedNotes"));
            drawTexture.LoadImage(textureData);
            drawTexture.Apply();
        }
    }

    Vector2Int ToVector2Int(Vector2 vector)
    {
        return new Vector2Int(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y));
    }
}
