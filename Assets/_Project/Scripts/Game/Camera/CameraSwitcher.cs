using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitcher : MonoBehaviour
{

    private Vector3 FirstPersonCam_Pos = new(0, 2, 0);
    private Vector3 ThirdPersonCam_Pos = new(0, -2, 0);
    private Vector3 Underground_Pos = new(0, -50, 0);
    private Vector3 Overground_Pos = new(0, +50, 0);
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
                //transform.position = new Vector3(0, transform.position.y, (float)-3.334);
                FirstPersonCam.enabled = false;
                ThirdPersonCam.enabled = true;
                Person.transform.Translate(Overground_Pos);
            }
            else
            {
                this.transform.Translate(FirstPersonCam_Pos);
                //transform.position = new Vector3(0, transform.position.y, 0);
                FirstPersonCam.enabled = true;
                ThirdPersonCam.enabled = false;
                Person.transform.Translate(Underground_Pos);

            }
            FirstPerson = !FirstPerson;
        }
    }
}
