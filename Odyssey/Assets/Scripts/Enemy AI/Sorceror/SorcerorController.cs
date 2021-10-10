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

    //navmesh 
    NavMeshAgent agent;

    private void OnEnable()
    {
        //set wander timer
        timer = wanderTimer;

        //set navmesh agent
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
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
}
