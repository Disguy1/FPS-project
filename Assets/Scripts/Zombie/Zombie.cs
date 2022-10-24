using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] float Health;
    [SerializeField] float Damage;
    [SerializeField] float Speed;

    NavMeshAgent agent;
    PlayerController controller;

    private void OnEnable()
    {
        WaveSystem.AliveZombies++;

        Health = WaveVariable.Value(WaveSystem.CurrentSettings.ZombieHealth);
        Damage = WaveVariable.Value(WaveSystem.CurrentSettings.ZombieDamage);
        Speed = WaveVariable.Value(WaveSystem.CurrentSettings.ZombieSpeed);

        agent = GetComponent<NavMeshAgent>();
        agent.speed = Speed;

        controller = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        MoveZombie();
    }

    private void MoveZombie()
    {
        agent.SetDestination(PlayerPos());
    }

    Vector3 PlayerPos()
    {
        return new Vector3(controller.transform.position.x, transform.position.y, controller.transform.position.z);
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            GetComponent<ZombieDeathManager>().Die();
        }
    }
}
