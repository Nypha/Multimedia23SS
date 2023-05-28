using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TV : MonoBehaviour
{
    [SerializeField] private Renderer noiseRenderer;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject videoObject;

    private bool isOn;
    private int channel;

    private List<Texture2D> noiseTextures;
    private MaterialPropertyBlock propBlock;


    private void Awake()
    {
        propBlock = new MaterialPropertyBlock();
        noiseTextures = new List<Texture2D>();
        for (int i = 0; i < 60; i++)
        {
            noiseTextures.Add(CreateNoiseTexture(i, 720, 576));
        }

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

    private Texture2D CreateNoiseTexture(float seed, int width, int height)
    {
        var texture = new Texture2D(width, height);
        var colors = new Color32[width * height];
        var i = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var value = UnityEngine.Random.Range(0f, 1f);
                // var value = Mathf.PerlinNoise((x + (seed * 1000) % 137) / 100, (y + (seed * 1000) % 137) / 100);
                colors[i] = new Color32((byte)(value * 255), (byte)(value * 255), (byte)(value * 255), 255);
                i++;
            }
        }
        texture.SetPixels32(colors);
        texture.Apply();
        return texture;
    }
}
