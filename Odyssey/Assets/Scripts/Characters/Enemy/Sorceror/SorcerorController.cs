using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SorcerorController : MonoBehaviour
{
    
    [SerializeField]bool attackMode;

    //things for navmesh agent
    GameObject target;
    NavMeshAgent agent;
    Animator animator;

    //projectile
    [SerializeField] private Transform projectile;
    [SerializeField] private GameObject staffEndPoint;
    [SerializeField] private Transform aimSpot;

    //slots for sorceror
    [SerializeField]  GameObject[] attackSlots;
    [SerializeField]  Transform sorcerorSlot;
    [SerializeField] Transform nextSlot;
    float BestSlot;
    bool flee;
    

    private void OnEnable()
    {
        
        //navmesh
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        //get all slots into list
        attackSlots = GameObject.FindGameObjectsWithTag("SorcerorSlot");
        FindSlot();


    }

    private void Update()
    {
        if (attackMode)
        {
            Attack();
        }
        else if(flee)
        {
            Flee();
        }
        else
        {
            GoToSlot();
        }
    }

    private void GoToSlot()
    {
        if (Vector3.Distance(target.transform.position, transform.position) <= 3)
        {
            flee = true;


        }
        agent.destination = sorcerorSlot.position;
        if (Vector3.Distance(sorcerorSlot.position, transform.position) < 1)
        {
            attackMode = true;
        }
    }

    private void Attack()
    {
        //disable agent we dont want him to move right now
        agent.enabled = false;

        //track player across chamber
        transform.LookAt(target.transform);

        //check for distances and test to see where the player is 
        if (Vector3.Distance(target.transform.position, transform.position) <= 30 && Vector3.Distance(target.transform.position, transform.position) >= 2)
        {
            Debug.Log("sorcerorAttack");
            animator.SetTrigger("Attack");
        }
        else if(Vector3.Distance(target.transform.position, transform.position) <= 3)
        {
            flee = true;
            attackMode = false;
            agent.enabled = true;
        }
    }

    //event to be called on mage attack animation
    //shoots projectiles at player
    private void ShootProjectile()
    {
        Transform projectile_transform = Instantiate(projectile, staffEndPoint.transform.position, Quaternion.identity);
        Vector3 shootDirection = (aimSpot.position - staffEndPoint.transform.position).normalized;
        projectile_transform.GetComponent<Projectile>().Setup(shootDirection, staffEndPoint.transform.position, this.gameObject);
    }

    void FindSlot()
    {
        //find new slot
        //find shortest distance away
        foreach(GameObject go in attackSlots)
        {
            //check if slot is free
            if(!go.GetComponent<Sorceror_Slot>().isTaken)
            {
                //check distance
                float distance = Vector3.Distance(go.transform.position, transform.position);
                float distanceFromPlayer = Vector3.Distance(go.transform.position, transform.position);
                //check if distance has been set
                if (BestSlot != 0)
                {
                    //if closer then best slot so far make that the next slot
                    if (distance < BestSlot)
                    {
                        BestSlot = distance;
                        nextSlot = go.transform;
                    }
                }
                else
                {
                    BestSlot = distance;
                    nextSlot = go.transform;
                }
            }
        }


        //once we checked all slots now we set and forget
        nextSlot.GetComponent<Sorceror_Slot>().isTaken = true;

        //set old location to free
        if(sorcerorSlot != null)
            sorcerorSlot.GetComponent<Sorceror_Slot>().isTaken = false;

        //set new location
        sorcerorSlot = nextSlot;
        BestSlot = 0;
    }

    void Flee()
    {
        if (Vector3.Distance(target.transform.position, transform.position) >= 8)
        {
            FindSlot();
            flee = false;
        }
        else
        {
            //get direction to player
            Vector3 dirToPlayer = transform.position - target.transform.position;

            //set a new position for navmesh to go to
            Vector3 newPos = transform.position + dirToPlayer;

            //set the destination for the navmesh agent
            agent.SetDestination(newPos);
        }
    }
    
}
