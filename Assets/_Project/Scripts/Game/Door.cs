using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform anchor;
    [SerializeField] private float yRotationOpen;
    [SerializeField] private AudioSource spraySound;


    private bool isOpen;
    private Vector3 initialDoorState;


    private void Start()
    {
        GameSceneManager.Instance.OnResetScene += OnReset;
        initialDoorState = anchor.localEulerAngles;
    }

    private void OnReset()
    {
        isOpen = false;
        anchor.localEulerAngles = initialDoorState;
    }

    private void Update()
    {
        if (isOpen && anchor.localEulerAngles.y < yRotationOpen)
        {
            anchor.transform.Rotate(Vector3.up, yRotationOpen * Time.deltaTime, Space.Self);
        }
    }
    private void OnDestroy()
    {
        GameSceneManager.Instance.OnResetScene -= OnReset;
    }

    public void Open()
    {
        isOpen = true;
        spraySound.Play();
    }
}
