using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform anchor;
    [SerializeField] private float yRotationOpen;

    private bool isOpen;

    private void Update()
    {
        if (isOpen && anchor.localEulerAngles.y < yRotationOpen)
        {
            anchor.transform.Rotate(Vector3.up, yRotationOpen * Time.deltaTime, Space.Self);
        }
    }

    public void Open()
    {
        isOpen = true;
    }
}
