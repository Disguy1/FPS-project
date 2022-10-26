using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeathManager : MonoBehaviour
{
    public void Die()
    {
        // Minus one from the number WaveSystem.AliveZombies and destroy the object this script is attached to.
        Debug.LogWarning("This script is not finished and needs to be get from someone on the team because of a push issue");
        WaveSystem.AliveZombies--;
        WaveSystem.ZombiesKilled++;
        Destroy(gameObject);
    }
}
