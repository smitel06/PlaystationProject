using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclopsWeapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        

        Vector3 moveDirection;
        //knockback
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hit player");
            
            other.GetComponent<Rigidbody>().AddForce(transform.forward * -500f);
        }
    }
}
