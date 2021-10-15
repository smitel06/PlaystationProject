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

        //let root motion take control
        agent.updatePosition = false;
        agent.updateRotation = true;

        //set wander timer
        timer = wanderTimer;

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
        

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || animator.GetCurrentAnimatorStateInfo(0).IsName("SpinAttack"))
        {
            agent.enabled = false;
        }
        else
        {
            agent.enabled = true;
        }

        if (AttackMode)
        {
            //stuff for root motion control
            agent.nextPosition = transform.position;

            if (agent.isActiveAndEnabled)
                agent.destination = target.transform.position;
        }
        else
        {
            timer += Time.deltaTime;
            //check to see how long we have been wandering for
            if (timer >= wanderTimer)
            {
                //find a new spot to wander to
                Vector3 newPosition = RandomNavSphere(transform.position, wanderRadius, -1);
                if (agent.isActiveAndEnabled)
                {
                    agent.SetDestination(newPosition);
                    timer = 0;
                }
            }
            
        }
    }

    void UpdateAnimator()
    {
        //work out decimal percentage of distance
        //multiply that by max velocity of the last animation in blend tree
        //add value to blend to change root motion speed
        float maxVelocity = 4.245843f;
        float blend = 1.638454f;

        if (AttackMode)
        {
            percentageOfMaxDistance = currentDistanceFromPlayer / maxDistanceFromPlayer;
            blend = maxVelocity * percentageOfMaxDistance;
            if (blend > maxVelocity)
            {
                blend = maxVelocity;
            }
        }

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
            animator.SetBool("canAttack", false);
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

    private static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        //create random direction
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;

        //check where we hit
        NavMeshHit navHit;

        //is this point on the navmesh
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        //return the position for wander to use
        return navHit.position;
    }


}
