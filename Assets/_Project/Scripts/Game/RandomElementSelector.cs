using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomElementSelector : MonoBehaviour
{
    [SerializeField] private List<GameObject> elements;

    private void Awake()
    {
        elements.ForEach(e => e.SetActive(false));
        elements.RandomElement().SetActive(true);
    }
}
