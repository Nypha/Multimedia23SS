using System.Collections.Generic;
using UnityEngine;

public class LevelStaircaseLogic : MonoBehaviour
{
    [SerializeField] private List<GameObject> paths;

    
    private void Start()
    {
        GameSceneManager.Instance.OnResetScene += OnResetScene;
        EnableStaircase();
    }
    private void OnDestroy()
    {
        GameSceneManager.Instance.OnResetScene -= OnResetScene;
    }

    private void OnResetScene()
    {
        EnableStaircase();
    }

    private void EnableStaircase()
    {
        paths.ForEach(p => p.SetActive(false));
        paths.RandomElement().SetActive(true);
    }
}