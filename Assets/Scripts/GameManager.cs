using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { idle, spawning }
    public static GameState CurrentGameState;
    public WaveSetting lol;
}
