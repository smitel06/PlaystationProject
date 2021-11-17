using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] public GameObject player;
    

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Enemy")
        {
            
            damage = player.GetComponent<Damage>().currentDamage;
            other.GetComponent<Health>().TakeDamage(damage);
            GetComponent<Collider>().enabled = false;
            
        }
    }
}
