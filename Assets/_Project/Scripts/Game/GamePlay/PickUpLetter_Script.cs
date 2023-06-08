using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PickUpLetter_Script : MonoBehaviour
{

    [SerializeField]
    private Image note;

    public GameObject MessagePanel;
    public GameObject KeyPanel;
    public bool InReach = false;
    public InputAction pickUp;

    public void Start()
    {
        MessagePanel.SetActive(false);
        KeyPanel.SetActive(false);
        note.enabled = false;
    }

    void Update()
    {
        if(Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (note.enabled == true)
            {
                note.enabled = false;
            }

            if (InReach == true)
            {
                if(note.enabled == false)
                {
                    MessagePanel.SetActive(false);
                    KeyPanel.SetActive(false);
                    InReach = false;
                    note.enabled = true;
                }
            }
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MessagePanel.SetActive(true);
            KeyPanel.SetActive(true);
            InReach = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MessagePanel.SetActive(false);
            KeyPanel.SetActive(false);
            InReach = false;
            note.enabled = false;
        }
    }
}
