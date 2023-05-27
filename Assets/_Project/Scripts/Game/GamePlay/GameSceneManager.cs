using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance { get; private set; }

    public event Action OnResetScene;


    [SerializeField] private float maxTimeSeconds;
    [SerializeField] private float toggleTimerUiSecondsLeft;
    [SerializeField] private CharacterController player;

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
            timerTime += Time.deltaTime;
            if (!hasTimerUiToggled && maxTimeSeconds - timerTime < toggleTimerUiSecondsLeft)
            {
                hasTimerUiToggled = true;
                GameUI.Instance.ShowTimer();
            }
            if (hasTimerUiToggled)
            {
                GameUI.Instance.SetTimer(toggleTimerUiSecondsLeft / (maxTimeSeconds - timerTime));
            }
        }
    }

    public void ResetScene()
    {
        isTimerRunning = false;
        hasTimerUiToggled = false;
        // player.GetComponent<WarpCharacterController>().WarpToPosition(playerStartPosition);

        player.enabled = false;
        player.transform.localPosition = playerStartPosition;
        player.enabled = true;

        OnResetScene?.Invoke();
    }

    public void StartTimer()
    {
        isTimerRunning = true;
        timerTime = 0;
    }
}