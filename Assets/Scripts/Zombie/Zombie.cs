using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] float Health;
    [SerializeField] float Damage;
    [SerializeField] float Speed;

    private void OnEnable()
    {
        Health = WaveVariable.Value(WaveSystem.CurrentSettings.ZombieHealth);
        Damage = WaveVariable.Value(WaveSystem.CurrentSettings.ZombieDamage);
        Speed = WaveVariable.Value(WaveSystem.CurrentSettings.ZombieSpeed);
    }

    private void Update()
    {
        MoveZombie();
    }

    private void MoveZombie()
    {
        transform.position = Vector3.MoveTowards(transform.position, FindObjectOfType<PlayerController>().transform.position, Time.deltaTime * Speed);
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            GetComponent<ZombieDeathManager>().Die();
        }
    }
}
