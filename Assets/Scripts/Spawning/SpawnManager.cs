using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Have a public variable of a new GameObject caled Zombie
    public GameObject zombie;
    

    public void Spawn()
    {
        // Instantiate the Zombie object with position of SpawnPosition.RandomPos().
        Instantiate (zombie, SpawnPosition.RandomPos(), Quaternion.identity);
    }
}
