using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingHandler : MonoBehaviour
{
    [SerializeField] private Renderer shoes;
    [SerializeField] private Renderer pants;
    [SerializeField] private Renderer pullover;

    private MaterialPropertyBlock propBlockShoes;
    private MaterialPropertyBlock propBlockPants;
    private MaterialPropertyBlock propBlockPullover;

    private void Update()
    {
        if (Settings.PlayerCustomizationDirty)
        {
            Settings.PlayerCustomizationDirty = false;
            shoes.gameObject.SetActive(Settings.HasShoes);
            pants.gameObject.SetActive(Settings.HasPants);
            pullover.gameObject.SetActive(Settings.HasPullover);

            propBlockShoes.SetColor("_BaseColor", Settings.StyleShoes);
            propBlockPants.SetColor("_BaseColor", Settings.StylePants);
            propBlockPullover.SetColor("_BaseColor", Settings.StylePullover);
            shoes.SetPropertyBlock(propBlockShoes);
            pants.SetPropertyBlock(propBlockPants);
            pullover.SetPropertyBlock(propBlockPullover);
        }
    }
}
