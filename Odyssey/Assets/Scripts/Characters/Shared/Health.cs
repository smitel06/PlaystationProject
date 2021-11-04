using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    [SerializeField] Slider healthBar;
    
    private void OnEnable()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
            healthBar.maxValue = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        if(GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().SetTrigger("Damaged");
                              
        }
        currentHealth -= damage;
        DamagePopUp.Create(this.transform.position, damage);

        if (GetComponent<SkullController>() != null)
        {
            
            GetComponent<SkullController>().damageSound();
        }
        else if (GetComponent<CyclopsController>() != null)
        {
            
            GetComponent<CyclopsController>().damageSound();
        }
        else if (GetComponent<SorcerorController>() != null)
        {
            
            GetComponent<SorcerorController>().damageSound();
        }
        else if (GetComponent<PlayerController>() != null)
        {
            
            GetComponent<PlayerController>().damageSound();
        }
    }

    void Update()
    {
        if(healthBar != null)
            healthBar.value = currentHealth;
    }

    public void changeMaxValue(int amount)
    {
        maxHealth += amount;
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            currentHealth = maxHealth;
        }
    }

    
    
}
