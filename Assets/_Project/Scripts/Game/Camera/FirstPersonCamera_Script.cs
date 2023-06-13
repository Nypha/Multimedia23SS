using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public Vector3 offset = new Vector3(0, 3, 0);
    public float camX = 0.0f;
    public float camY = 0.0f;
    public bool up = true;

    // Start is called before the first frame update
    void Start()
    {
        //Camera main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
        //Debug.Log("Players position: " + player.position);
        //Debug.Log("Cameras position: " + transform.position);

        camX = Input.GetAxis("Mouse X");
        //camY = Input.GetAxis("Mouse Y");
        Camera.main.transform.Rotate(camY, camX, 0);
        //Debug.Log("Cameras rotation: " + transform.rotation);
        if (Input.anyKey)
        {

            if (up)
            {
                offset.y += 0.005f;
            }
            else
            {
                offset.y -= 0.005f;

            }

            if (offset.y > 2.5)
            {
                up = false;
            }

            if (offset.y < 2)
            {
                up = true;
            }
        }

    }
}
