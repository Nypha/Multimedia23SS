﻿using System;
using System.Collections;
using System.Collections.Generic;
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
    [Space]
    [SerializeField] private Button bnContinue;
    [SerializeField] private Button bnReset;
    [SerializeField] private Button bnExit;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI tfSliderValue;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject loadingOverlay;

    [Space]
    [SerializeField] private GameObject gameEndScreen;
    [SerializeField] private TextMeshProUGUI tfGameEnd;
    [SerializeField] private TextMeshProUGUI tfGameEnd2;
    [SerializeField] private Button bnGameEndReset;
    [SerializeField] private Button bnGameEndExit;

    [Space]
    [SerializeField] private Toggle toggle0;
    [SerializeField] private TMP_Dropdown dropdown0;
    [SerializeField] private Toggle toggle1;
    [SerializeField] private TMP_Dropdown dropdown1;
    [SerializeField] private Toggle toggle2;
    [SerializeField] private TMP_Dropdown dropdown2;
    [SerializeField] private List<Color> styles;


    private float minimapTargetAlpha;
    private bool animateEndScreen;


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
        bnGameEndExit.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Menu_Scene");
            loadingOverlay.SetActive(true);
        });
        bnReset.onClick.AddListener(() =>
        {
            GameSceneManager.Instance.ResetScene();
            HideMenu();
        });
        bnGameEndReset.onClick.AddListener(() =>
        {
            GameSceneManager.Instance.ResetScene();
            HideGameEndScreen();
        });
        slider.onValueChanged.AddListener(OnSetVolume);
        slider.SetValueWithoutNotify(Settings.Volume);
        inputField.onValueChanged.AddListener(OnSetPlayerName);
        inputField.SetTextWithoutNotify(Settings.PlayerName);

        toggle0.onValueChanged.AddListener((isOn) =>
        {
            Settings.PlayerCustomizationDirty = true;
            Settings.HasShoes = isOn;
        });
        toggle1.onValueChanged.AddListener((isOn) =>
        {
            Settings.PlayerCustomizationDirty = true;
            Settings.HasPants = isOn;
        });
        toggle2.onValueChanged.AddListener((isOn) =>
        {
            Settings.PlayerCustomizationDirty = true;
            Settings.HasPullover = isOn;
        });

        dropdown0.onValueChanged.AddListener((value) =>
        {
            Settings.PlayerCustomizationDirty = true;
            Settings.StyleShoes = styles[value];
        });
        dropdown1.onValueChanged.AddListener((value) =>
        {
            Settings.PlayerCustomizationDirty = true;
            Settings.StylePants = styles[value];
        });
        dropdown2.onValueChanged.AddListener((value) =>
        {
            Settings.PlayerCustomizationDirty = true;
            Settings.StylePullover = styles[value];
        });

        toggle0.isOn = Settings.HasShoes;
        toggle1.isOn = Settings.HasPants;
        toggle2.isOn = Settings.HasPullover;
        dropdown0.value = 2;
        dropdown1.value = 1;
        dropdown2.value = 2;
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

        if (animateEndScreen)
        {
            AnimateText(tfGameEnd);
            AnimateText(tfGameEnd2);
        }

        if (mainMenu.activeSelf)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void HideMenu()
    {
        mainMenu.SetActive(false);
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
        tfDeathKeyHint.text = $"Press <i>[{displayName}]</i> for more time!";
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

    public void ShowGameEndScreen()
    {
        gameEndScreen.SetActive(true);
        tfGameEnd.text = tfGameEnd2.text = $"You made it out alive, <i>{Settings.PlayerName}</i>!";
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        animateEndScreen = true;
    }
    public void HideGameEndScreen()
    {
        gameEndScreen.SetActive(false);
        animateEndScreen = false;
    }
    private void AnimateText(TextMeshProUGUI textField)
    {
        textField.ForceMeshUpdate();
        var textInfo = textField.textInfo;
        for (int i = 0; i < textField.textInfo.characterInfo.Length; ++i)
        {
            var charInfo = textInfo.characterInfo[i];
            if (charInfo.isVisible)
            {
                var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;
                for (int j = 0; j < 4; ++j)
                {
                    var orig = verts[charInfo.vertexIndex + j];
                    verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x * 0.01f) * 10f, 0);
                }
            }
        }
        for (int i = 0; i < textInfo.meshInfo.Length; ++i)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            textField.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}