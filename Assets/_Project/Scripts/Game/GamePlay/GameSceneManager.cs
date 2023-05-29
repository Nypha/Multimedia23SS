using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance { get; private set; }

    public event Action OnResetScene;


    [SerializeField] private float maxTimeSeconds;
    [SerializeField] private float toggleTimerUiSecondsLeft;
    [SerializeField] private float timeAddPerKeyPress;
    [SerializeField] private CharacterController player;
    [SerializeField] private Volume deathVolume; 

    private Vector3 playerStartPosition;

    private bool isTimerRunning;
    private float timerTime;
    private bool hasTimerUiToggled;

    private KeyControl currentTimerControl;


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
        deathVolume.weight = 0f;
        playerStartPosition = player.transform.localPosition;
    }
    private void Start()
    {
        GetNextTimerControl();
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

        if (isTimerRunning)
        {
            timerTime -= Time.deltaTime;
            deathVolume.weight = 1f - (timerTime / maxTimeSeconds);

            if (!hasTimerUiToggled && timerTime < toggleTimerUiSecondsLeft)
            {
                hasTimerUiToggled = true;
                GameUI.Instance.ShowTimer();
            }

            if (hasTimerUiToggled)
            {
                GameUI.Instance.SetTimer(timerTime / toggleTimerUiSecondsLeft);
            }

            if (timerTime <= 0)
            {
                ResetScene();
                GameUI.Instance.ShowDeathHint(5);
            }
        }

        if (hasTimerUiToggled && currentTimerControl != null)
        {
            if (currentTimerControl.wasPressedThisFrame)
            {
                timerTime += timeAddPerKeyPress;
                GetNextTimerControl();
            }
        }
    }

    private void GetNextTimerControl()
    {
        switch (Random.Range(0, 10))
        {
            case 0: currentTimerControl = Keyboard.current.uKey; break;
            case 1: currentTimerControl = Keyboard.current.pKey; break;
            case 2: currentTimerControl = Keyboard.current.lKey; break;
            case 3: currentTimerControl = Keyboard.current.jKey; break;
            case 4: currentTimerControl = Keyboard.current.mKey; break;
            case 5: currentTimerControl = Keyboard.current.hKey; break;
            case 6: currentTimerControl = Keyboard.current.nKey; break;
            case 7: currentTimerControl = Keyboard.current.tKey; break;
            case 8: currentTimerControl = Keyboard.current.bKey; break;
            case 9: currentTimerControl = Keyboard.current.iKey; break;
        }
        GameUI.Instance.SetTimerInputText(currentTimerControl.displayName);
    }

    public void ResetScene()
    {
        isTimerRunning = false;
        hasTimerUiToggled = false;
        deathVolume.weight = 0f;
        // player.GetComponent<WarpCharacterController>().WarpToPosition(playerStartPosition);

        player.enabled = false;
        player.transform.localPosition = playerStartPosition;
        player.enabled = true;

        OnResetScene?.Invoke();
    }

    public void StartTimer()
    {
        isTimerRunning = true;
        timerTime = maxTimeSeconds;
    }
}