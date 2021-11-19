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
    public void TakeDamage(int damage)
    {
        if(GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().SetTrigger("Damaged");
                              
        }

        if (GetComponent<playerBuffs>() != null)
        {
            //check for hardened warrior 
            if(GetComponent<playerBuffs>().hardenedWarrior)
            {
                damage = damage - (damage / 3);
            }

            if(GetComponent<Dash>().lightningQ)
            {
                damage = 0;
                GetComponent<Dash>().lightningQ = false;
            }
        }
        currentHealth -= damage;
        DamagePopUp.Create(this.transform.position, damage);

        if(GetComponent<CharacterSounds>() != null)
            GetComponent<CharacterSounds>().PlayImpactSound();

        if(GetComponent<SkullController>() != null)
        {
            GetComponent<SkullController>().materialSwap();
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
