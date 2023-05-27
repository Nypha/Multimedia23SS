using System.Collections;
using UnityEngine;


public class WarpCharacterController : MonoBehaviour
{
    private Vector3 warpPosition = Vector3.zero;
    public void WarpToPosition(Vector3 newPosition)
    {
        warpPosition = newPosition;
    }
    void LateUpdate()
    {
        if (warpPosition != Vector3.zero)
        {
            transform.position = warpPosition;
            warpPosition = Vector3.zero;
        }
    }
}