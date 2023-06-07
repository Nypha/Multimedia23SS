using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PuzzleRoom1_WD40 : MonoBehaviour
{
    public bool isPickedUp = false;
    public GameObject MessagePanel;
    public GameObject KeyPanel;
    public GameObject WD40;
    public bool InReach = false;
    public InputAction pickUp;

    public void Start()
    {
        MessagePanel.SetActive(false);
        MessagePanel.gameObject.SetActive(false);
        KeyPanel.gameObject.SetActive(false);
        KeyPanel.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (InReach == true)
            {
                MessagePanel.SetActive(false);
                KeyPanel.SetActive(false);
                WD40.SetActive(false);
                InReach = false;
                isPickedUp = true;
            }
        }
    }

    void OnTriggerEnter(Collider WD40)
    {
        if (WD40.CompareTag("Player"))
        {
            MessagePanel.SetActive(true);
            KeyPanel.SetActive(true);

            MessagePanel.gameObject.SetActive(false);
            KeyPanel.gameObject.SetActive(false);
            InReach = true;
        }
    }

    private void OnTriggerExit(Collider WD40)
    {
        if (WD40.CompareTag("Player"))
        { 
            MessagePanel.SetActive(false);
            KeyPanel.SetActive(false);
            InReach = false;
        }
    }
}
