using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//this script controls enemy behaviour
public class EnemyController : MonoBehaviour
{
    //attack slot variables
	GameObject target = null;
	float pathTime = 0f;
	int slot = -1;
    
    //get navmesh agent
    NavMeshAgent agent;

    //wandering function 
    public float wanderRadius;
    public float wanderTimer;
    float timer;

    //control each state
    float distanceFromTarget;
    public float swapDistance;


    // Use this for initialization
    void OnEnable()
	{
		//Find the player
		target = GameObject.Find("Player");
        //set navmesh agent
        agent = GetComponent<NavMeshAgent>();
        //set wander timer
        timer = wanderTimer;
    }

	// Update is called once per frame
	void Update()
    {
        RunStateMachine();

    }

    private void RunStateMachine()
    {
        distanceFromTarget = Vector3.Distance(transform.position, target.transform.position);
        if (distanceFromTarget <= swapDistance)
        {
            FindSlot();
        }
        else
            Wander();
    }

    //find an attackSlot
    private void FindSlot()
    {
        //check players position every 0.5 seconds
        //create an offset from that position
        pathTime += Time.deltaTime;
        if (pathTime > 0.5f)
        {
            pathTime = 0f;
            var slotManager = target.GetComponent<EnemySlots>();
            //check for slot manager
            if (slotManager != null)
            {
                //check if slot is empty
                if (slot == -1)
                    slot = slotManager.Reserve(gameObject);
                if (slot == -1)
                    return;
                
                //check if navmesh exists
                if (agent == null)
                    return;
                agent.destination = slotManager.GetSlotPosition(slot);
            }
        }
    }

    //randomly wander around in a given radius
    private void Wander()
    {
        //this will be our first state used to make enemies randomly move around
        timer += Time.deltaTime;
        //check to see how long we have been wandering for
        if(timer >= wanderTimer)
        {
            //find a new spot to wander to
            Vector3 newPosition = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPosition);
            timer = 0;
        }

    }

    //find a location on the navmesh within a randomised sphere
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

    public void Attack()
    {
        //use close distance attack method used in diablo games
    }
}

