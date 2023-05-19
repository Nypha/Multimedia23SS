using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance { get; private set; }

    public event Action OnResetScene;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Logger.LogError(LogCategory.Scenes, $"Scene manager already set to {Instance.name}!");
        }
    }
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (GameUI.Instance.IsMenuActive)
            {
                GameUI.Instance.HideMenu();
            }
            else
            {
                GameUI.Instance.ShowMenu();
            }
        }
    }

    public void ResetScene()
    {
        OnResetScene?.Invoke();
    }

    internal static object GetActiveScene()
    {
        throw new NotImplementedException();
    }
}