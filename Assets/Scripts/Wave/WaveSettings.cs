using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "New Wave Settings", menuName = "Game/Wave Settings")]
public class WaveSettings : ScriptableObject
{
    /// <summary>
    /// Amount of seconds to wait before spawning new zombies.
    /// </summary>
    [HideInInspector] public WaveSetting SpawnInterval = new WaveSetting(2, 4, 1, 0);
    /// <summary>
    /// Amount of most zombies that can be alive at a time.
    /// </summary>
    [HideInInspector] public WaveSetting MostZombieCount = new WaveSetting(5, 7, 1, 0);
    /// <summary>
    /// Amount of zombies that spawn at once.
    /// </summary>
    [HideInInspector] public WaveSetting SpawnGroupCount = new WaveSetting(1, 2, 1, 0);
    /// <summary>
    /// Health a zombie will spawn with.
    /// </summary>
    [HideInInspector] public WaveSetting ZombieHealth = new WaveSetting(100, 110, 1, 0);
    /// <summary>
    /// Damage a zombie will deal.
    /// </summary>
    [HideInInspector] public WaveSetting ZombieDamage = new WaveSetting(10, 15, 1, 0);
    /// <summary>
    /// Speed a zombie can run.
    /// </summary>
    [HideInInspector] public WaveSetting ZombieSpeed = new WaveSetting(4, 4.5f, 1, 0);


#if UNITY_EDITOR
    [CustomEditor(typeof(WaveSettings))]
    public class WaveSettingsEditor : Editor
    {
        float defaultSpace = 10f;
        public override void OnInspectorGUI()
        {
            WaveSettings _target = (WaveSettings)target;

            base.OnInspectorGUI();
            GUILayout.Label("Zombie Spawn Interval", EditorStyles.boldLabel);

            GUILayout.Space(defaultSpace);

            GUILayout.Label(new GUIContent("Spawn Interval", "Amount of seconds to wait before spawning new zombies."));
            GUILayout.BeginHorizontal();
            GUILayout.Label("Min");
            _target.SpawnInterval.MinValue = EditorGUILayout.FloatField(_target.SpawnInterval.MinValue);
            GUILayout.Label("Max");
            _target.SpawnInterval.MaxValue = EditorGUILayout.FloatField(_target.SpawnInterval.MaxValue);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Every");
            _target.SpawnInterval.RoundInterval = EditorGUILayout.IntField(_target.SpawnInterval.RoundInterval);
            GUILayout.Label("waves the Spawn Interval goes up by");
            _target.SpawnInterval.ValueIncrement = EditorGUILayout.FloatField(_target.SpawnInterval.ValueIncrement);
            GUILayout.EndHorizontal();
            GUILayout.Space(defaultSpace / 2f);


            GUILayout.Space(defaultSpace);
            GUILayout.Label("Zombie Spawn Amount", EditorStyles.boldLabel);
            GUILayout.Space(defaultSpace);

            GUILayout.Label(new GUIContent("Most Zombie Count", "Amount of most zombies that can be alive at a time."));
            GUILayout.BeginHorizontal();
            GUILayout.Label("Min");
            _target.MostZombieCount.MinValue = EditorGUILayout.FloatField(_target.MostZombieCount.MinValue);
            GUILayout.Label("Max");
            _target.MostZombieCount.MaxValue = EditorGUILayout.FloatField(_target.MostZombieCount.MaxValue);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Every");
            _target.MostZombieCount.RoundInterval = EditorGUILayout.IntField(_target.MostZombieCount.RoundInterval);
            GUILayout.Label("waves the Most Zombie Count goes up by");
            _target.MostZombieCount.ValueIncrement = EditorGUILayout.FloatField(_target.MostZombieCount.ValueIncrement);
            GUILayout.EndHorizontal();
            GUILayout.Space(defaultSpace / 2f);

            GUILayout.Label(new GUIContent("Spawn Group Count", "Amount of zombies that spawn at once."));
            GUILayout.BeginHorizontal();
            GUILayout.Label("Min");
            _target.SpawnGroupCount.MinValue = EditorGUILayout.FloatField(_target.SpawnGroupCount.MinValue);
            GUILayout.Label("Max");
            _target.SpawnGroupCount.MaxValue = EditorGUILayout.FloatField(_target.SpawnGroupCount.MaxValue);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Every");
            _target.SpawnGroupCount.RoundInterval = EditorGUILayout.IntField(_target.SpawnGroupCount.RoundInterval);
            GUILayout.Label("waves the Spawn Group Count goes up by");
            _target.SpawnGroupCount.ValueIncrement = EditorGUILayout.FloatField(_target.SpawnGroupCount.ValueIncrement);
            GUILayout.EndHorizontal();
            GUILayout.Space(defaultSpace / 2f);

            GUILayout.Space(defaultSpace);
            GUILayout.Label("Zombie Spawn Settings", EditorStyles.boldLabel);
            GUILayout.Space(defaultSpace);

            GUILayout.Label(new GUIContent("Zombie Heath", "Health a zombie will spawn with."));
            GUILayout.BeginHorizontal();
            GUILayout.Label("Min");
            _target.ZombieHealth.MinValue = EditorGUILayout.FloatField(_target.ZombieHealth.MinValue);
            GUILayout.Label("Max");
            _target.ZombieHealth.MaxValue = EditorGUILayout.FloatField(_target.ZombieHealth.MaxValue);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Every");
            _target.ZombieHealth.RoundInterval = EditorGUILayout.IntField(_target.ZombieHealth.RoundInterval);
            GUILayout.Label("waves the Zombie Health goes up by");
            _target.ZombieHealth.ValueIncrement = EditorGUILayout.FloatField(_target.ZombieHealth.ValueIncrement);
            GUILayout.EndHorizontal();
            GUILayout.Space(defaultSpace / 2f);

            GUILayout.Label(new GUIContent("Zombie Damage", "Damage a zombie will deal."));
            GUILayout.BeginHorizontal();
            GUILayout.Label("Min");
            _target.ZombieDamage.MinValue = EditorGUILayout.FloatField(_target.ZombieDamage.MinValue);
            GUILayout.Label("Max");
            _target.ZombieDamage.MaxValue = EditorGUILayout.FloatField(_target.ZombieDamage.MaxValue);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Every");
            _target.ZombieDamage.RoundInterval = EditorGUILayout.IntField(_target.ZombieDamage.RoundInterval);
            GUILayout.Label("waves the Zombie Damage goes up by");
            _target.ZombieDamage.ValueIncrement = EditorGUILayout.FloatField(_target.ZombieDamage.ValueIncrement);
            GUILayout.EndHorizontal();
            GUILayout.Space(defaultSpace / 2f);

            GUILayout.Label(new GUIContent("Zombie Speed", "Speed a zombie can run."));
            GUILayout.BeginHorizontal();
            GUILayout.Label("Min");
            _target.ZombieSpeed.MinValue = EditorGUILayout.FloatField(_target.ZombieSpeed.MinValue);
            GUILayout.Label("Max");
            _target.ZombieSpeed.MaxValue = EditorGUILayout.FloatField(_target.ZombieSpeed.MaxValue);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Every");
            _target.ZombieSpeed.RoundInterval = EditorGUILayout.IntField(_target.ZombieSpeed.RoundInterval);
            GUILayout.Label("waves the Zombie Speed goes up by");
            _target.ZombieSpeed.ValueIncrement = EditorGUILayout.FloatField(_target.ZombieSpeed.ValueIncrement);
            GUILayout.EndHorizontal();
            GUILayout.Space(defaultSpace / 2f);
        }
    }
    #endif
}
