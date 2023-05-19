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
    public bool InReach = false;
    public InputAction pickUp;

    public void Start()
    {
        MessagePanel.SetActive(false);
        note.enabled = false;
    }

    void Update()
    {
        if(Keyboard.current.eKey.IsPressed())
        {
            if(InReach == true)
            {
                MessagePanel.SetActive (false);
                InReach = false;
                note.enabled = true;
            }
        }
        Logger.Log("Updated");

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MessagePanel.SetActive(true);
            InReach = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MessagePanel.SetActive(false);
            InReach = false;
            note.enabled = false;
        }
    }
}
