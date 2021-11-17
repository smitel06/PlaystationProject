using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaShardAttack : MonoBehaviour
{
    public GameObject shardParticle;
    [SerializeField] GameObject particlePosition;
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
            attack = false;
        }
    }


    //animation event
    void ShardHit()
    {
        controller.movement.canMove = false;
        Instantiate(shardParticle, particlePosition.transform.position, particlePosition.transform.rotation);
        controller.movement.canMove = true;
        attack = false;
    }

}
