using System;
using UnityEngine;

[CreateAssetMenu(menuName = Constants.AssetMenu.ROOT_CAMERA + "CameraConfig")]
public class CameraConfig : ScriptableObject
{
    [SerializeField] private Setting movementSensitivity;
    public Setting MovementSensitivity => movementSensitivity;

    [SerializeField] private Setting rotationSensitivity;
    public Setting RotationSensitivity => rotationSensitivity;

    [SerializeField] private bool invertYRotation;
    public bool InvertYRotation => invertYRotation;


    [Serializable]
    public struct Setting
    {
        public float gamepad;
        public float keyboardAndMouse;
    }
}
