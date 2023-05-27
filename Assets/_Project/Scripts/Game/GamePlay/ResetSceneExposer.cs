using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ResetSceneExposer : MonoBehaviour
{

    public UnityEvent onResetScene;
    private void Start()
    {
        GameSceneManager.Instance.OnResetScene += OnReset;
    }
    private void OnDestroy()
    {
        GameSceneManager.Instance.OnResetScene -= OnReset;
    }

    private void OnReset()
    {
        onResetScene?.Invoke();
    }
}