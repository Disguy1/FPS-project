using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitchInput : MonoBehaviour
{
    private void Update()
    {
        // If the player presses 1 (KeyCode.Alpha1) switch the GunSwitchManager.CurrentGun to GunSwitchManager.Gun.Pistol. If the player presses 2 (KeyCode.Alpha2) switch it to GunSwitchManager.Gun.M16 and if 3 (KeyCode.Alpha3) switch it to GunSwitchManager.Gun.Shotgun
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GunSwitchManager.CurrentGun = GunSwitchManager.Gun.Pistol;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GunSwitchManager.CurrentGun = GunSwitchManager.Gun.M16;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GunSwitchManager.CurrentGun = GunSwitchManager.Gun.Shotgun;
        }
    }
}
