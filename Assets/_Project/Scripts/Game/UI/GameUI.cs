using System;
using System.Collections;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance { get; private set; }
    public bool IsMenuActive => mainMenu.activeSelf;


    [SerializeField] private CanvasGroup minimap;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject characterController;
    [SerializeField] private float minimapAlphaSpeed;


    private float minimapTargetAlpha;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Logger.LogError(LogCategory.Scenes, $"UI already set to {Instance.name}!");
        }

        HideMinimap(false);
    }
    private void Start()
    {
        GameSceneManager.Instance.OnResetScene += OnResetScene;
    }
    private void Update()
    {
        if (minimap.alpha < minimapTargetAlpha)
        {
            minimap.alpha += minimapAlphaSpeed * Time.deltaTime;
            if (minimap.alpha >= minimapTargetAlpha)
            {
                minimap.alpha = minimapTargetAlpha;
            }
        }
        else if (minimap.alpha > minimapTargetAlpha)
        {
            minimap.alpha -= minimapAlphaSpeed * Time.deltaTime;
            if (minimap.alpha >= minimapTargetAlpha)
            {
                minimap.alpha = minimapTargetAlpha;
            }
        }
    }

    private void OnResetScene()
    {
        HideMinimap(false);
    }

    public void ShowMenu()
    {
        mainMenu.SetActive(true);
        characterController.SetActive(false);
    }
    public void HideMenu()
    {
        mainMenu.SetActive(false);
        characterController.SetActive(true);
    }

    public void ShowMinimap()
    {
        minimapTargetAlpha = 1f;
    }
    public void HideMinimap(bool animate = true)
    {
        minimapTargetAlpha = 0f;
        if (!animate)
        {
            minimap.alpha = 0f;
        }
    }    
}