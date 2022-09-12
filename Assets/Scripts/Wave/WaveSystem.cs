using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [Header("Wave Manager")]
    public bool CanSpawn = true;

    [Header("Wave Variables")]
    [SerializeField] WaveSettings CurrentWaveSettings;

    private void Update()
    {
        if (CanSpawn) Spawn();
    }

    void Spawn()
    {
        
    }
}
