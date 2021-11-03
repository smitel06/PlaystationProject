using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] GameObject player;
    

    private void OnTriggerEnter(Collider other)
    {
        //knockback
        if (other.gameObject.tag == "Enemy")
        {
            
            damage = player.GetComponent<Damage>().currentDamage;
            other.GetComponent<Health>().TakeDamage(damage);
            Debug.Log(other.GetComponent<Health>().currentHealth);
            
        }
    }
}
