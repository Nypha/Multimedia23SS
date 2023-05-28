using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance { get; private set; }

    public event Action OnResetScene;


    [SerializeField] private float maxTimeSeconds;
    [SerializeField] private float toggleTimerUiSecondsLeft;
    [SerializeField] private CharacterController player;
    [SerializeField] private Volume deathVolume; 

    private Vector3 playerStartPosition;

    private bool isTimerRunning;
    private float timerTime;
    private bool hasTimerUiToggled;


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