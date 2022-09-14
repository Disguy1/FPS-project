using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootManager : MonoBehaviour
{
    // Have a public variable for the player camera caled PlayerCam.


    public void Shoot(float Damage, float Range)
    {
        // Shoot a raycast from the centre of the PlayerCam within the range of Range. If the raycast hits an object with a tag of Zombie, get the Zombie component from it and call TakeDamage() while passing the Damage variable.

    }
}
