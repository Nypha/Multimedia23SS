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
    [SerializeField] private bool deactivateAfterInput = true;
    [SerializeField] private GameObject ui;
    

    private bool isActiveForInput;


    private void Start()
    {
        ui.SetActive(false);
    }
    private void Update()
    {
        if (isActiveForInput)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
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
}