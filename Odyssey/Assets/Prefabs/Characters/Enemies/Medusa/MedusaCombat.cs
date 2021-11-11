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

    //projectile variables
    [SerializeField] Transform attack2Projectile;
    [SerializeField] Transform attack3Projectile;
    [SerializeField] GameObject attack2Origin;
    Transform aimspot;
    int attack2Limit = 10;
   
    

    private void Start()
    {
        controller = GetComponent<MedusaController>();
        timerAttack = attackTimer;
        aimspot = controller.player.GetComponent<PlayerController>().aimspot;
    }

    private void Update()
    {
        distance = Vector3.Distance(controller.player.position, transform.position);

        if (attackType == 1)
            ShardAttack();
        if (attackType == 2)
            Attack2Projectile();
        if (attackType == 3)
            Attack3Projectile();

    }

    private void ShardAttack()
    {
        ///set movement to if particle is playing
        if (shardAttack.shardParticle.isPlaying)
        {
            controller.movement.canMove = false;
        }
        else
        {
            controller.movement.canMove = true;
        }

        
        if (distance <= attackRange && timerAttack <= 0 && !shardAttack.shardParticle.isPlaying)
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

    private void Attack2Projectile()
    {
        if (distance <= 12f && timerAttack <= 0)
        {
            controller.animatorController.animator.SetTrigger("attack2");
        }
        else
        {
            timerAttack -= Time.deltaTime;
        }
    }

    private void Attack3Projectile()
    {
        controller.movement.agent.updatePosition = false;
        controller.animatorController.animator.SetTrigger("attack3");
    }

    public void Attack2Event()
    {
        Transform projectile_transform = Instantiate(attack2Projectile, attack2Origin.transform.position, Quaternion.identity);
        Vector3 shootDirection = (aimspot.position - attack2Origin.transform.position).normalized;
        projectile_transform.GetComponent<ProjectileMedusa>().Setup(shootDirection, attack2Origin.transform.position, this.gameObject);
        timerAttack = 0.25f;
    }

}
