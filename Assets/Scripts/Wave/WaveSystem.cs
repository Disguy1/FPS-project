using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [Header("Wave Manager")]
    public bool CanSpawn = true;
    public static int WaveNum = 1;

    [Header("Wave Variables")]
    [SerializeField] WaveSettings currentSettings;
    public static WaveSettings CurrentSettings;


    SpawnManager _Spawn;
    public static int AliveZombies = 0;
    [SerializeField] int AliveZombiesForInspector;

    private void Update()
    {
        CurrentSettings = currentSettings;

        AliveZombiesForInspector = AliveZombies;
        if (Input.GetKeyDown(KeyCode.K))
        {
            WaveSystem.AliveZombies--;
        }
    }

    private void Awake()
    {
        _Spawn = FindObjectOfType<SpawnManager>();
        CurrentSettings = currentSettings;
    }

    private void Start()
    {
        if (CanSpawn) StartCoroutine(SpawnCycle());
    }

    IEnumerator SpawnCycle()
    {
        int MostZombieCount = Mathf.RoundToInt(WaveVariable.Value(CurrentSettings.MostZombieCount));

        while (CanSpawn)
        {
            while (AliveZombies < MostZombieCount)
            {
                yield return new WaitForSeconds(WaveVariable.Value(CurrentSettings.SpawnInterval));

                int SpawnGroupCount = Mathf.RoundToInt(WaveVariable.Value(CurrentSettings.SpawnGroupCount));
                for (int i = SpawnGroupCount; i > 0; i--)
                {
                    if (AliveZombies < MostZombieCount)
                    {
                        _Spawn.Spawn();
                    }
                    else
                    {
                        break;
                    }
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
