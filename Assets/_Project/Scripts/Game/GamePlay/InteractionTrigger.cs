using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InteractionTrigger : MonoBehaviour
{
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;
    public UnityEvent onCallback;


    [SerializeField] private Collider trigger;
    [SerializeField] private Key key;
    [SerializeField] private bool deactivateAfterInput = true;
    [SerializeField] private GameObject ui;
    

    private bool isActiveForInput;


    private void Start()
    {
        ui.SetActive(false);
        GameSceneManager.Instance.OnResetScene += OnReset;
    }
    private void Update()
    {
        if (isActiveForInput)
        {
            bool wasPressed = false;
            switch (key)
            {
                case Key.E:
                    wasPressed = Keyboard.current.eKey.wasPressedThisFrame;
                    break;
                case Key.R:
                    wasPressed = Keyboard.current.rKey.wasPressedThisFrame;
                    break;
            }

            if (wasPressed)
            {
                onCallback?.Invoke();
                if (deactivateAfterInput)
                {
                    trigger.enabled = false;
                    isActiveForInput = false;
                    ui.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out _))
        {
            isActiveForInput = true;
            onTriggerEnter?.Invoke();
            ui.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out _))
        {
            isActiveForInput = false;
            onTriggerExit?.Invoke();
            ui.SetActive(false);
        }
    }
    private void OnDestroy()
    {
        GameSceneManager.Instance.OnResetScene -= OnReset;
    }

    private void OnReset()
    {
        if (deactivateAfterInput)
        {
            trigger.enabled = true;
        }
    }

    private enum Key
    {
        E = 0,
        R = 1,
    }
}