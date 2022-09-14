using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    public static SpawnPosition Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] Transform[] SpawnPositions;
    public static Vector3 RandomPos()
    {
        return Instance.SpawnPositions[Random.Range(0, Instance.SpawnPositions.Length - 1)].position;
    }
}
