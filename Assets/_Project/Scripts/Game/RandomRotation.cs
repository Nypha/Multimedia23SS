using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    [SerializeField] private List<Vector3> selection;
    private void Awake()
    {
        transform.localEulerAngles = selection.RandomElement();
    }
}
