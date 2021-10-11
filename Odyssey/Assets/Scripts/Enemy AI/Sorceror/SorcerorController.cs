using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SorcerorController : MonoBehaviour
{
    //wandering function 
    public float wanderRadius;
    public float wanderTimer;
    float timer;
    [SerializeField]bool attacking;

    //things for navmesh agent
    GameObject target;
    NavMeshAgent agent;
    Animator animator;

    //projectile
    [SerializeField] private Transform projectile;
    [SerializeField] private GameObject staffEndPoint;
    [SerializeField] private Transform aimSpot;

    private void OnEnable()
    {
        //set wander timer
        timer = wanderTimer;

        //navmesh
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (attacking)
        {
            Attack();
        }
        else
            Wander();
    }

    private void Wander()
    {
        //this will be our first state used to make enemies randomly move around
        timer += Time.deltaTime;
        //check to see how long we have been wandering for
        if (timer >= wanderTimer)
        {
            //find a new spot to wander to
            Vector3 newPosition = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPosition);
            timer = 0;
        }

    }

    //find a location on the navmesh within a randomised sphere
    //this will decide where to wander to
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

    private void Attack()
    {
        agent.destination = target.transform.position;
        
        
        if(Vector3.Distance(target.transform.position, transform.position) <= 15)
        {
            agent.enabled = false;
            transform.LookAt(target.transform);
            animator.SetTrigger("Attack");
            agent.enabled = true;
            //attacking = false;
        }
    }

    //event to be called on mage attack animation
    //shoots projectiles at player
    private void ShootProjectile()
    {
        Transform projectile_transform = Instantiate(projectile, staffEndPoint.transform.position, Quaternion.identity);
        Vector3 shootDirection = (aimSpot.position - staffEndPoint.transform.position).normalized;
        projectile_transform.GetComponent<Projectile>().Setup(shootDirection, staffEndPoint.transform.position);
    }

    
}
