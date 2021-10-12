using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    public float currentHealth;
    
    private void OnEnable()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        GetComponent<Animator>().SetTrigger("Damaged");
        currentHealth -= damage;
    }
}
