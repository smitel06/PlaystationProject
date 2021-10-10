using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclopsWeapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    { 
        //knockback
        if (other.gameObject.tag == "Player")
        {
            //add things here for player triggers when hit by cyclops
        }
    }
}
