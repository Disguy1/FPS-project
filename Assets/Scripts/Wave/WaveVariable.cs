using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveVariable : MonoBehaviour
{
    public static float Value(WaveSetting _setting)
    {
        return Random.Range(_setting.MinValue, _setting.MaxValue);
    }
}
