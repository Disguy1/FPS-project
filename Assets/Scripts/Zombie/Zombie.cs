using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] float Health;
    [SerializeField] float Damage;
    [SerializeField] float Speed;
    [SerializeField] float attackInterval = 1f;
    float attackTime;

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
        CheckForAttack();
    }

    private void MoveZombie()
    {
        agent.SetDestination(PlayerPos());
    }

    void CheckForAttack()
    {
        if (Vector3.Distance(PlayerPos(), transform.position) <= 2)
        {
            agent.isStopped = true;
            Attack();
        }
        else
        {
            agent.isStopped = false;
            attackTime = 0;
        }
    }

    void Attack()
    {
        if (attackTime <= 0)
        {
            controller.health -= Damage;
            attackTime = attackInterval;
        }
        else
        {
            attackTime -= Time.deltaTime;
        }
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
