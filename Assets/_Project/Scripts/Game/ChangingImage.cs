using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ChangingImage : MonoBehaviour
{
    [SerializeField] private new Renderer renderer;
    [SerializeField] private bool setAlternatingNoise;
    [SerializeField] private List<Texture2D> textures;
    [SerializeField] private bool startRandom;
    [SerializeField] private Color noiseColor = Color.white;

    private MaterialPropertyBlock propBlock;
    private List<Texture2D> noiseTextures;

    private int textureIndex;
    private bool showNoiseTexture;


    public void SwapImage()
    {
        if (setAlternatingNoise)
        {
            showNoiseTexture = !showNoiseTexture;
            if (!showNoiseTexture)
            {
                SetTexture(textures[textureIndex]);
                textureIndex++;
                textureIndex %= textures.Count;
            }
        }
        else
        {
            SetTexture(textures[textureIndex]);
            textureIndex++;
            textureIndex %= textures.Count;
        }
    }

    private void Awake()
    {
        if (setAlternatingNoise)
        {
            noiseTextures = NoiseTextureMaker.CreateNoiseTextures(300, 400, 60, noiseColor, false);
        }
        SetTexture(textures[startRandom ? Random.Range(0, textures.Count) : 0]);
    }
    private void Update()
    {
        if (showNoiseTexture)
        {
            SetTexture(noiseTextures[Time.frameCount % noiseTextures.Count]);
        }
    }

    private void SetTexture(Texture2D texture)
    {
        if (propBlock == null)
        {
            propBlock = new MaterialPropertyBlock();
        }
        propBlock.SetTexture("_Texture", texture);
        renderer.SetPropertyBlock(propBlock);
    }
}
