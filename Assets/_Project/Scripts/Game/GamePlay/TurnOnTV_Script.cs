using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Experimental.Video;

public class TurnOnTV_Script : MonoBehaviour
{

    [SerializeField]
    private VideoClipPlayable clip;

    public GameObject MessagePanel;
    public bool InReach = false;
    public InputAction pickUp;

    public void Start()
    {
        MessagePanel.SetActive(false);
        //clip = false;
    }

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (InReach == true)
            {
                /*if (clip == false)
                {
                    MessagePanel.SetActive(false);
                    InReach = false;
                    //clip = true;
                }
                else if (clip == true)
                {
                    //clip = false;
                }*/
            }
        }
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
            //clip.enabled = false;
        }
    }
}
