using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkullController : MonoBehaviour
{
    //wandering function 
    public float wanderRadius;
    public float wanderTimer;
    float timer;
    [SerializeField] bool isAttacking;

    //things for navmesh agent
    GameObject target;
    NavMeshAgent agent;
    Animator animator;

    //attacking
    [SerializeField] private Transform aimSpot;
    [SerializeField] float moveSpeed = 0;
    

    private void OnEnable()
    {
        //set wander timer
        timer = wanderTimer;

        //navmesh
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(isAttacking)
        {
            Attacking();
        }
        else
        {
            Wander();
        }

        
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

    private void Attacking()
    {
        transform.LookAt(target.transform);
        Vector3 shootDirection = (aimSpot.position - transform.position).normalized;
        transform.position += shootDirection * moveSpeed * Time.deltaTime;
    }
}
