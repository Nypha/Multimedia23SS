using UnityEngine;
using UnityEngine.Events;

public class PuzzleRoom1 : MonoBehaviour
{
    public UnityEvent onComplete;

    [SerializeField] private bool isComplete;

    private bool prevComplete;
    private void Update()
    {
        if (isComplete && !prevComplete)
        {
            onComplete?.Invoke();
        }
        prevComplete = isComplete;
    }
}
