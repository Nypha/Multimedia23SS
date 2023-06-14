using UnityEngine;
using UnityEngine.Events;

public class RenderEventForwarder : MonoBehaviour
{
    public UnityEvent onBecameVisible;
    public UnityEvent onBecameInvisible;

    private void OnBecameVisible()
    {
        onBecameVisible?.Invoke();
    }
    private void OnBecameInvisible()
    {
        onBecameInvisible?.Invoke();
    }
}
