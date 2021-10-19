using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CyclopsController : MonoBehaviour
{
    //things for navmesh agent
    GameObject target;
    NavMeshAgent agent;
    Animator animator;

    //attack variables
    [SerializeField] float attackRange;

    //common variables
    [SerializeField] float maxDistanceFromPlayer;
    [SerializeField] float currentDistanceFromPlayer;
    [SerializeField] float percentageOfMaxDistance;

    //weapon controls
    [SerializeField]Collider weaponCollider;

    //wandering function 
    [SerializeField] float wanderRadius;
    [SerializeField] float wanderTimer;
    float timer;
    [SerializeField] bool AttackMode;


    void OnEnable()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        //set wander timer
        timer = wanderTimer;

    }

    // Update is called once per frame
    void Update()
    {
        if (target.GetComponent<PlayerController>().dead == false)
        {
            //distance from player will be used in a few ways
            currentDistanceFromPlayer = Vector3.Distance(transform.position, target.transform.position);

            UpdateAgent();
            UpdateAnimator();
            UpdateAttacking();
        }
        else
        {
            animator.SetTrigger("Idle");
        }
        
    }

    private void UpdateAgent()
    {
        
        //check animator for attack animation
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            agent.enabled = false;
            animator.applyRootMotion = true;
        }
        else
        {
            agent.enabled = true;
            animator.applyRootMotion = false;
        }

        if (AttackMode)
        {

            UpdateAttacking();
        }
        
        
    }

    void UpdateAnimator()
    {
        float blend = 1.638454f;
        animator.SetFloat("Blend", blend);  
    }

    //update attacks
    void UpdateAttacking()
    {
        if (currentDistanceFromPlayer <= attackRange && currentDistanceFromPlayer > 2.5 && AttackMode)
        {
            agent.enabled = false;
            
            animator.SetBool("canAttack", true);
        }
        else
        {
            agent.enabled = true;
            animator.SetBool("canAttack", false);
            agent.destination = target.transform.position;
        }

        
    }

    //what happens when hit event is called on animation
    public void Hit(string attackName)
    {
        weaponCollider.enabled = true;

    }

    public void FootL()
    {
        //footsteps???
    }

    public void FootR()
    {
        //footsteps???
    }

    //turns off collider
    void FinishedAttacking()
    {
        weaponCollider.enabled = false;
    }

    public void TakeDamage()
    {
        GetComponent<Animator>().SetTrigger("Damaged");
    }


}
