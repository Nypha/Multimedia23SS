using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChance : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] 
    private float spawnChance;

    private void Awake()
    {
        gameObject.SetActive(Random.value <= spawnChance);
    }
}
