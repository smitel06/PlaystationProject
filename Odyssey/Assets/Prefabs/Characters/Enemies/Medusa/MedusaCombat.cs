using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaCombat : MonoBehaviour
{
    MedusaController controller;

    //attacks enum and shared variables
    public int attackType;
    float attackRange = 6.5f;
    public float attackTimer;
    float timerAttack;
    float distance;
    
    float timerMove;
    //shard attack variables
    [SerializeField]MedusaShardAttack shardAttack = null;
   
    

    private void Start()
    {
        controller = GetComponent<MedusaController>();
        
        timerAttack = attackTimer;
    }

    private void Update()
    {
        ///set movement to if particle is playing
        if(shardAttack.shardParticle.isPlaying)
        {
            controller.movement.canMove = false;
        }
        else
        {
            controller.movement.canMove = true;
        }

        distance = Vector3.Distance(controller.player.position, transform.position);
        if(distance <= attackRange && timerAttack <= 0 && !shardAttack.shardParticle.isPlaying)
        {
            controller.movement.canMove = false;
            shardAttack.attack = true;
            timerAttack = attackTimer;
            
        }
        else
        {
            shardAttack.attack = false;
            timerAttack -= Time.deltaTime;
        }
        
    }

    
}
