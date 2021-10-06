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
            animator.SetTrigger("Attack");
        }
        else
        {
            animator.SetTrigger("Moving");
        }
    }
}
