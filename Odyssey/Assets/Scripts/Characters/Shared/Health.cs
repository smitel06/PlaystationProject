using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    public float currentHealth;
    [SerializeField] Slider healthBar;
    
    private void OnEnable()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        GetComponent<Animator>().SetTrigger("Damaged");
        currentHealth -= damage;
    }

    void Update()
    {
        healthBar.value = currentHealth;
    }

    
    
}
