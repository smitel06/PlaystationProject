using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclopsWeapon : MonoBehaviour
{
    [SerializeField] GameObject cyclops;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("cyclops hit player");
        //knockback
        if (other.gameObject.tag == "Player")
        {
            
            other.GetComponent<Health>().TakeDamage(cyclops.GetComponent<Damage>().currentDamage);
        }
    }
}
