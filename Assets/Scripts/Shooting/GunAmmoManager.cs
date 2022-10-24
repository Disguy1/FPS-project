using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunAmmoManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ammoText;
    //[Header("Current Ammo settings")]
    //[SerializeField] float currentAmmo, currentMaxAmmo;
    //[Space]
    //[Header("M16")]
    //[SerializeField] float m16ammo, m16maxAmmo;

    public static int CurrentAmmo = 15;
    public static int MaxAmmo = 15;
    public static int M16Ammo = 15;
    public static int M16maxAmmo = 15;

    int DefaultCurrentAmmo;
    int DefaultMaxAmmo;
    int DefaultM16Ammo;
    int DefaultM16maxAmmo;

    private void OnEnable()
    {
        DefaultCurrentAmmo = CurrentAmmo;
        DefaultMaxAmmo = MaxAmmo;
        DefaultM16Ammo = M16Ammo;
        DefaultM16maxAmmo = M16maxAmmo;
    }

    private void OnDisable()
    {
        CurrentAmmo = DefaultCurrentAmmo;
        MaxAmmo = DefaultMaxAmmo;
        M16Ammo = DefaultM16Ammo;
        M16maxAmmo = DefaultM16maxAmmo;
    }

    private void Update()
    {
        ammoText.text = CurrentAmmo + "/" + MaxAmmo;
    }
}
