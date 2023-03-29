using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CameraConfig config;
    [SerializeField] private CameraInputCollector inputCollector;
    [Space]
    [SerializeField] private new Camera camera;
    [SerializeField] private Transform xAxis;
}
