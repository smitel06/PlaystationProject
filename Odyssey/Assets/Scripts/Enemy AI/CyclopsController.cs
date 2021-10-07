using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CyclopsController : MonoBehaviour
{
    GameObject target;
    NavMeshAgent agent;
    Animator animator;

    //attack variables
    [SerializeField] float attackRange;
    [SerializeField] int attackCount;

    
    void OnEnable()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAgent();
        UpdateAnimator();
        UpdateAttacking();
    }

    private void UpdateAgent()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            agent.enabled = false;
        }
        else
        {
            agent.enabled = true;
        }

        agent.destination = target.transform.position;
    }

    void UpdateAnimator()
    {
        Vector3 velocity = agent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        animator.SetFloat("Blend", speed);

    }

    void UpdateAttacking()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= attackRange)
        {
            animator.SetBool("canAttack", true);
            //check for previous attacks so we can do a periodic spin attack every third attack
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
            {
                attackCount++;
            }
            
            if (attackCount < 3)
            {
                animator.SetBool("Attack1", true);
                animator.SetBool("spinAttack", false);
            }
            else
            {
                animator.SetBool("Attack1", false);
                animator.SetBool("spinAttack", true);
                attackCount = 0;
            }
        }
        else
            animator.SetBool("canAttack", false);

    }
}
