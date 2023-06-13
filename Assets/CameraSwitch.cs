using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    [SerializeField] private Transform position0;
    [SerializeField] private Transform position1;
    [SerializeField] private Vector2 fovSettings;
    [SerializeField] private AnimationCurve switchCurve;
    [SerializeField] private float switchTimeSpan = 0.25f;
    [Space]
    [SerializeField] private List<Renderer> toDisable;


    private Vector3 TargetPosition => position == 0 ? position0.localPosition : position1.localPosition;
    private Quaternion TargetRotation => position == 0 ? position0.localRotation : position1.localRotation;
    private float TargetFov => position == 0 ? fovSettings.x : fovSettings.y;

    private int position;
    private float switchTimer;

    private void Update()
    {
        if (Keyboard.current.leftCtrlKey.wasPressedThisFrame)
        {
            Switch();
        }
         
        switchTimer += Time.deltaTime;
        // if (switchTimer <= switchTimeSpan)
        // {
            camera.transform.localPosition = Vector3.Lerp(camera.transform.localPosition, TargetPosition, switchCurve.Evaluate(switchTimer));
            camera.transform.localRotation = Quaternion.Lerp(camera.transform.localRotation, TargetRotation, switchCurve.Evaluate(switchTimer));
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, TargetFov, switchCurve.Evaluate(switchTimer));
        // }
    }

    private void Switch()
    {
        position = position == 0 ? 1 : 0;
        switchTimer = 0f;
        toDisable.ForEach(r => r.enabled = position == 0);
    }
}
