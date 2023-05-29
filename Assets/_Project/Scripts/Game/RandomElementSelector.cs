using System.Collections.Generic;
using UnityEngine;

public class RandomElementSelector : MonoBehaviour
{
    [SerializeField] private List<GameObject> elements;


    private void Start()
    {
        GameSceneManager.Instance.OnResetScene += OnResetScene;
        SelectElement();
    }
    private void OnResetScene()
    {
        SelectElement();
    }
    private void SelectElement()
    {
        elements.ForEach(e => e.SetActive(false));
        elements.RandomElement().SetActive(true);
    }
}
