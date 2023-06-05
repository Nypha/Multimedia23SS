using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WD40_Riddle_Room1 : MonoBehaviour
{


    [SerializeField]
    int PickedUpWD40;

    AudioSource puzzleSolved;
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
        if (PickedUpWD40 >= 4)
        {
            puzzleSolved.Play();
            //isCompleted == true;
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (InReach == true)
            {
                MessagePanel.SetActive(false);
                KeyPanel.SetActive(false);
                WD40.SetActive(false);
                PickedUpWD40++;
                InReach = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MessagePanel.SetActive(true);
            KeyPanel.SetActive(true);

            MessagePanel.gameObject.SetActive(false);
            KeyPanel.gameObject.SetActive(false);
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
        }
    }
}
