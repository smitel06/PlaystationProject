﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMedusa : MonoBehaviour
{
    private Vector3 shootDirection;
    [SerializeField] float moveSpeed = 0;
    [SerializeField] Vector3 scaleUp = new Vector3(1,1,1);
    
    float timer;

    [SerializeField] ParticleSystem particle;
    bool moveParticle = false;
    bool scaleParticle = true;
    [SerializeField] GameObject medusa;
   
    public void Setup(Vector3 shootDirection, Vector3 position, GameObject summoner)
    {
        timer = 3.5f;
        medusa = summoner;
        transform.position = position;
        this.shootDirection = shootDirection;
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(shootDirection));
        
    }

    private void Update()
    {
        if(scaleParticle && particle.transform.localScale.x <= 5)
        {
            particle.transform.localScale += scaleUp;
        }
        else if(scaleParticle)
        {
            medusa.GetComponent<MedusaController>().animatorController.animator.enabled = true;
            moveParticle = true;
            moveSpeed = 5f;
            scaleParticle = false;
        }

        if (moveParticle)
        {
            transform.position += shootDirection * moveSpeed * Time.deltaTime;
        }

        if (timer <= 0)
        {
             //particle.Stop();
        }
        else
            timer -= Time.deltaTime;
    }

    public static float GetAngleFromVectorFloat(Vector3 direction)
    {
        direction = direction.normalized;
        float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            other.GetComponent<Health>().TakeDamage(5);
            GetComponent<Collider>().enabled = false;
        }

        particle.gameObject.SetActive(false);

        moveParticle = false;

    }
}


