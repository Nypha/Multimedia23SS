using System.Collections.Generic;
using UnityEngine;

public class LevelStaircaseLogic : MonoBehaviour
{
    [SerializeField] private List<GameObject> paths;


    private void Awake()
    {
        paths.ForEach(p => p.SetActive(false));
        paths.RandomElement().SetActive(true);
    }
}