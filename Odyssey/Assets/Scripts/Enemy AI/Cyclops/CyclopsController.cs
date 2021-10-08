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

    //movement variables
    bool isMoving;

    //common variables
    [SerializeField] float maxDistanceFromPlayer;
    [SerializeField] float currentDistanceFromPlayer;
    [SerializeField] float percentageOfMaxDistance;

    //weapon controls
    Collider weaponCollider;
    

    void OnEnable()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        //let root motion take control
        agent.updatePosition = false;
        agent.updateRotation = true;

        //weapon collider
        weaponCollider = GetComponentInChildren<Collider>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //distance from player will be used in a few ways
        currentDistanceFromPlayer = Vector3.Distance(transform.position, target.transform.position);
        

        UpdateAgent();
        UpdateAnimator();
        UpdateAttacking();
    }

    private void UpdateAgent()
    {
        //stuff for root motion control
        agent.nextPosition = transform.position;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || animator.GetCurrentAnimatorStateInfo(0).IsName("SpinAttack"))
        {
            agent.enabled = false;
        }
        else
        {
            agent.enabled = true;
        }

        if(agent.isActiveAndEnabled)
            agent.destination = target.transform.position;
    }

    void UpdateAnimator()
    {
        //work out decimal percentage of distance
        //multiply that by max velocity of the last animation in blend tree
        //add value to blend to change root motion speed
        float maxVelocity = 4.245843f;
        percentageOfMaxDistance = currentDistanceFromPlayer / maxDistanceFromPlayer;
        float blend = maxVelocity * percentageOfMaxDistance;
        if(blend > maxVelocity)
        {
            blend = maxVelocity;
        }
        animator.SetFloat("Blend", blend);  
    }

    //update attacks
    void UpdateAttacking()
    {
        if (currentDistanceFromPlayer <= attackRange)
        {
            animator.SetBool("canAttack", true);

            if (attackCount < 3)
            {
                animator.SetBool("Attack1", true);
                animator.SetBool("spinAttack", false);
            }
            else
            {
                animator.SetBool("Attack1", false);
                animator.SetBool("spinAttack", true);
                
            }
        }
        else
        {
            animator.SetBool("canAttack", false);
        }

        
    }

    //what happens when hit event is called on animation
    public void Hit(string attackName)
    {
        weaponCollider.enabled = true;
        //cycle attacks every three
        if (attackName == "basic")
        {
            attackCount++;
        }

        if (attackName == "special")
        {
            attackCount = 0;
        }
        
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


}
