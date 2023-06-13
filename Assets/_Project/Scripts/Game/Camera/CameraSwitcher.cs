using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitcher : MonoBehaviour
{

    private Vector3 FirstPersonCam_Pos = new(0, 2, 0);
    private Vector3 ThirdPersonCam_Pos = new(0, -2, 0);
    private bool FirstPerson = false;

    public Camera ThirdPersonCam;
    public Camera FirstPersonCam;
    public GameObject Person;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.f2Key.wasPressedThisFrame)
        {
            if (FirstPerson)
            {
                this.transform.Translate(ThirdPersonCam_Pos);
                FirstPersonCam.enabled = false;
                ThirdPersonCam.enabled = true;
                Person.SetActive(true);
            }
            else
            {
                //this.transform.position = this.transform.position + FirstPersonCam_Pos;
                this.transform.Translate(FirstPersonCam_Pos);
                FirstPersonCam.enabled = true;
                ThirdPersonCam.enabled = false;
                Person.SetActive(false);

            }
            FirstPerson = !FirstPerson;
        }
    }
}
