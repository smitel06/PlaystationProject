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
    
    

    private void OnEnable()
    {
        
        //navmesh
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        //get all slots into list
        attackSlots = GameObject.FindGameObjectsWithTag("SorcerorSlot");

        
        
    }

    private void Update()
    {
        if (attackMode)
        {
            Attack();
        }
        else
        {
            agent.destination = sorcerorSlot.position;
        }
        

        
    }


    private void Attack()
    {
        
        
        //check for distances and test to see where the player is 
        if(Vector3.Distance(target.transform.position, transform.position) <= 25 && Vector3.Distance(target.transform.position, transform.position) >= 10)
        {
            
            transform.LookAt(target.transform);
            animator.SetTrigger("Attack");
            
        }
        else if(Vector3.Distance(target.transform.position, transform.position) <= 10)
        {
            agent.enabled = true;
            attackMode = false;
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

    
    
}
