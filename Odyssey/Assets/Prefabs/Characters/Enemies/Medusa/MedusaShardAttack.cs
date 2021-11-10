using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaShardAttack : MonoBehaviour
{
    [SerializeField] ParticleSystem shardParticle;
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

    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Health>().TakeDamage(10);
        }
    }

    //animation event
    void Hit()
    {
        shardParticle.Play();
        attack = false;
    }

}
