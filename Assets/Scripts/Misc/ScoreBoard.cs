using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshPro>().text = WaveSystem.ZombiesKilled.ToString();
    }
}
