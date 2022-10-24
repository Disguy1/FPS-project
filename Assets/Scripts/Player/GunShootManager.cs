using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootManager : MonoBehaviour
{
    // Have a public variable for the player camera caled PlayerCam.
    public Camera playercam;



    public void Shoot(float Damage, float Range)
    {
        // Shoot a raycast from the centre of the PlayerCam within the range of Range. If the raycast hits an object with a tag of Zombie, get the Zombie component from it and call TakeDamage() while passing the Damage variable.
        RaycastHit hit;
        if (Physics.Raycast(playercam.transform.position, playercam.transform.TransformDirection(Vector3.forward), out hit, Range))
        {
            Debug.Log("Shot!" + hit.transform.name);
            if (hit.transform.tag == "Zombie")
            {
                hit.transform.GetComponent<Zombie>().TakeDamage(Damage); 
            }
        }
        
    }
}
