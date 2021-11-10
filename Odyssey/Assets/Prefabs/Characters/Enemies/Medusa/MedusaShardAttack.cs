using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaShardAttack : MonoBehaviour
{
    public ParticleSystem shardParticle;
    MedusaController controller;
    public bool attack;

    private void Start()
    {
        controller = GetComponent<MedusaController>();
    }

    //notes
    //shard finishes at position (0,0, 6.5) away
    private void Update()
    {
        if(attack)
        {
            //animation event to trigger attack
            controller.animatorController.animator.SetTrigger("shardAttack");
        }
    }


    //animation event
    void Hit()
    {
        controller.movement.canMove = false;
        shardParticle.Play();
        attack = false;
    }

}
