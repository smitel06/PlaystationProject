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


    //things for navmesh agent
    GameObject target;
    NavMeshAgent agent;
    [SerializeField] Animator animator;

    //attacking
    [SerializeField] private Transform aimSpot;
    [SerializeField] float moveSpeed = 0;
    [SerializeField] bool attackMode;
    [SerializeField] bool cooldown;
    Vector3 moveDirection;
    float cooldownTimer;
    Vector3 shootDirection;
    bool canAttack;

    private void OnEnable()
    {
        //set wander timer
        timer = wanderTimer;

        //navmesh
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
        if (attackMode)
        {
            StartCoroutine("Attacking");
            
        }
        else if (!cooldown && !attackMode)
        {
            Wander();
        }

        CooldownAttack();

        //can now attack after waitingf for pre attack animation
        if(canAttack)
        {
            shootDirection = (aimSpot.position - transform.position).normalized;
            transform.position += shootDirection * moveSpeed * Time.deltaTime;
        }
    }

    private void CooldownAttack()
    {
        if (cooldown && cooldownTimer <= 0.25f)
        {
            cooldownTimer += Time.deltaTime;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        else
        {
            cooldown = false;
            agent.enabled = true;
            GetComponent<Collider>().enabled = true;
            
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

    IEnumerator Attacking()
    {
        if(Vector3.Distance(target.transform.position, transform.position) < 6 && !cooldown)
        {
            agent.enabled = false;
            transform.LookAt(target.transform);
            animator.SetTrigger("Attack");
            attackMode = false;
            
            yield return new WaitForSeconds(1);
            canAttack = true;
            
        }
        else
        {
            attackMode = true;
            agent.enabled = true;
            agent.destination = target.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canAttack)
        {
            if (other.gameObject.tag == "Player")
            {
                GetComponent<Collider>().enabled = false;
                cooldownTimer = 0;
                other.GetComponent<Health>().TakeDamage(GetComponent<Damage>().currentDamage);
                moveDirection = (transform.position - other.transform.position).normalized;
                cooldown = true;
                canAttack = false;
            }
        }


    }
}
