using PlasticPipe.Client;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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
    [SerializeField] private TextMeshProUGUI tfDeathKeyHint;
    [SerializeField] private GameObject deathHint;
    // [SerializeField] private float menuTimer = 5f;
    // [SerializeField] private float menuTimerHint = 5f;
    // [SerializeField] private Slider menuTimerSlider;
    [Space]
    [SerializeField] private Button bnContinue;
    [SerializeField] private Button bnReset;
    [SerializeField] private Button bnExit;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI tfSliderValue;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject loadingOverlay;


    private float minimapTargetAlpha;

    // private bool escEverReleased;
    // private float escHoldTimer;
    // private bool startTimer;


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

        bnContinue.onClick.AddListener(() => HideMenu());
        bnExit.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Menu_Scene");
            loadingOverlay.SetActive(true);
        });
        bnReset.onClick.AddListener(() =>
        {
            GameSceneManager.Instance.ResetScene();
            HideMenu();
        });
        slider.onValueChanged.AddListener(OnSetVolume);
        slider.SetValueWithoutNotify(Settings.Volume);
        inputField.onValueChanged.AddListener(OnSetPlayerName);
        inputField.SetTextWithoutNotify(Settings.PlayerName);
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

        // if (Keyboard.current.escapeKey.wasPressedThisFrame)
        // {
        //     escHoldTimer = menuTimer;
        //     startTimer = true;
        // }
        // if (Keyboard.current.escapeKey.wasReleasedThisFrame)
        // {
        //     if (escEverReleased)
        //     {
        //         if (escHoldTimer > 0)
        //         {
        //             HideMenu();
        //         }
        //         else
        //         {
        //             SceneManager.LoadSceneAsync("Menu_Scene");
        //         }
        //     }
        //     else 
        //     {
        //         escEverReleased = true;
        //     }
        // }
        // menuTimerSlider.gameObject.SetActive(escHoldTimer < menuTimerHint);
        // menuTimerSlider.value = menuTimer - escHoldTimer;
        // if (startTimer)
        // {
        //     escHoldTimer -= Time.deltaTime;
        // }
    }

    private void OnResetScene()
    {
        HideMinimap(false);
        HideMenu();
        timerGo.SetActive(false);
        tfDeathKeyHint.text = string.Empty;
    }

    public void ShowMenu()
    {
        mainMenu.SetActive(true);
        characterController.SetActive(false);
        // escEverReleased = false;
        // startTimer = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
    public void SetTimerInputText(string displayName)
    {
        tfDeathKeyHint.text = $"Press [{displayName}] for more time!";
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


    private void OnSetPlayerName(string arg0)
    {
        Settings.PlayerName = arg0;
    }

    private void OnSetVolume(float arg0)
    {
        Settings.Volume = arg0;
        tfSliderValue.text = $"{arg0 * 100:n0}%";
    }
}