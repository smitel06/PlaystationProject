using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] GameObject explosion_fx;
    Health health;

    private void OnEnable()
    {
        //get health
        health = GetComponent<Health>();
    }

    private void Update()
    {
        if(health.currentHealth <= 0)
        {
            explosion_fx.SetActive(true);
        }
    }
}
