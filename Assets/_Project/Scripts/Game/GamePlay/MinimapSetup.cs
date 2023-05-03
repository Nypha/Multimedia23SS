using System;
using System.Collections;
using UnityEngine;

public class MinimapSetup : MonoBehaviour
{
    [SerializeField] private Camera minimapCamera;
    [SerializeField] private ColliderForwarder colliderForwarder;


    private void Start()
    {
        colliderForwarder.OnTriggerEnterEvent += OnTriggerEnter2;
        colliderForwarder.OnTriggerExitEvent += OnTriggerExit2;
    }

    private void OnTriggerEnter2(Collider other)
    {
        if (other.TryGetComponent<MinimapPlayer>(out _))
        {
            GameUI.Instance.ShowMinimap();
        }
    }
    private void OnTriggerExit2(Collider other)
    {
        if (other.TryGetComponent<MinimapPlayer>(out _))
        {
            GameUI.Instance.HideMinimap();
        }
    }
}