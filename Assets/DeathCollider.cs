using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out _))
        {
            GameSceneManager.Instance.ResetScene();
            GameUI.Instance.ShowDeathHint(5);
        }
    }
}
