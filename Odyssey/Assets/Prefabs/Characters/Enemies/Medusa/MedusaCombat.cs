using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaCombat : MonoBehaviour
{
    MedusaController controller;

    //attacks enum and shared variables
    public int attackType;
    bool canAttack;
    float attackRange = 6.5f;
    public float attackTimer = 3.0f;
    float distance;
    
    //shard attack variables
    [SerializeField]MedusaShardAttack shardAttack = null;
   
    

    private void Start()
    {
        controller = GetComponent<MedusaController>();
        
    }

    private void Update()
    {
        distance = Vector3.Distance(controller.player.position, transform.position);

        
        if(distance <= attackRange && attackTimer <= 0)
        {
            shardAttack.attack = true;
            controller.movement.canMove = false;
            attackTimer = 3.0f;
        }
        else
        {
            shardAttack.attack = false;
            controller.movement.canMove = true;
            attackTimer -= Time.deltaTime;
        }
    }

    
}
