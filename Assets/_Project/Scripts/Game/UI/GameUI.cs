using PlasticPipe.Client;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance { get; private set; }
    public bool IsMenuActive => mainMenu.activeSelf;


    [SerializeField] private CanvasGroup minimap;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject characterController;
    [SerializeField] private float minimapAlphaSpeed;
    [SerializeField] private GameObject timerGo;
    [SerializeField] private Slider timerSlider;
    [SerializeField] private GameObject deathHint;


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
        HideMenu();
        timerGo.SetActive(false);
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

    public void ShowTimer()
    {
        timerGo.SetActive(true);
        timerSlider.value = 0;
    }
    public void SetTimer(float progress)
    {
        timerSlider.value = progress;
    }

    public void ShowDeathHint(float duration)
    {
        StartCoroutine(ShowDeathHintCR(duration));
    }
    private IEnumerator ShowDeathHintCR(float duration)
    {
        deathHint.SetActive(true);
        yield return new WaitForSeconds(duration);
        deathHint.SetActive(false);
    }
}