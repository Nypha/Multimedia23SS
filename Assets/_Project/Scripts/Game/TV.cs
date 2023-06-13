using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TV : MonoBehaviour
{
    [SerializeField] private Renderer noiseRenderer;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject videoObject;
    [SerializeField] private Color noiseColor = Color.white;

    private bool isOn;
    private int channel;

    private List<Texture2D> noiseTextures;
    private MaterialPropertyBlock propBlock;


    private void Awake()
    {
        propBlock = new MaterialPropertyBlock();
        noiseTextures = NoiseTextureMaker.CreateNoiseTextures(720, 576, 60, noiseColor, true);
        isOn = true;
        HandleState();
    }
    private void Update()
    {
        if (channel == 1)
        {
            propBlock.SetTexture("_MainTex", noiseTextures[Time.frameCount % noiseTextures.Count]);
            noiseRenderer.SetPropertyBlock(propBlock);
        }
    }


    public void Toggle()
    {
        isOn = !isOn;
        HandleState();
    }
    public void CycleChannel() 
    {
        switch (channel)
        {
            case 0:
                channel = 1;
                videoObject.SetActive(false);
                noiseRenderer.gameObject.SetActive(true);
                break;

            case 1:
                channel = 0;
                videoObject.SetActive(true);
                noiseRenderer.gameObject.SetActive(false);
                break;
        }
    }

    private void HandleState()
    {
        if (isOn)
        {
            videoObject.SetActive(true);
            noiseRenderer.gameObject.SetActive(false);
        }
        else
        {
            videoObject.SetActive(false);
            noiseRenderer.gameObject.SetActive(false);
        }
    }    
}

public static class NoiseTextureMaker
{
    private static List<Texture2D> cachedTextures;

    public static List<Texture2D> CreateNoiseTextures(int width, int height, int count, Color color, bool forceNew)
    {
        if (cachedTextures == null)
        {
            cachedTextures = new List<Texture2D>();
        }

        var result = new List<Texture2D>();
        int missingTextures = count - cachedTextures.Count;
        for (int i = 0; i < missingTextures; i++)
        {
            cachedTextures.Add(CreateNoiseTexture(i, width, height, color));
        }
        var uniqueRandom = new List<int>();
        for (int i = 0; i < count; i++)
        {
            uniqueRandom.Add(i);
        }
        for (int i = 0; i < count; i++)
        {
            if (forceNew)
            {
                result.Add(CreateNoiseTexture(i, width, height, color));
            }
            else 
            { 
                var index = uniqueRandom.RandomElement();
                uniqueRandom.Remove(index);
                result.Add(cachedTextures[index]);
            }
        }

        return result;
    }
    public static Texture2D CreateNoiseTexture(float seed, int width, int height, Color color)
    {
        var texture = new Texture2D(width, height);
        var colors = new Color32[width * height];
        var i = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var value = UnityEngine.Random.Range(0f, 1f);
                var pixelColor = new Color32((byte)(value * color.r * 255), (byte)(value * color.g * 255), (byte)(value * color.b * 255), 255);
                colors[i] = pixelColor;
                i++;
            }
        }
        texture.SetPixels32(colors);
        texture.Apply();
        return texture;
    }
}