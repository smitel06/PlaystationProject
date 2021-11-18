using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SorcerorController : MonoBehaviour
{
    
    [SerializeField]bool attackMode;
    [SerializeField] GameObject sorcerorRoot;
    [SerializeField] ParticleSystem explosion_fx;
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

    //death functions
    bool dead;
    Health health;
    [SerializeField] GameObject healthbar;
    [SerializeField] GameObject shardBody;
    [SerializeField] GameObject body;
    [SerializeField] GameObject hood;
    [SerializeField] GameObject cloak;
    [SerializeField] GameObject weapon;
    float deathTimer;
    bool deathDone;
    [SerializeField] float attackFrequency;
    float attackSpeed;

    
    private void Start()
    {
        attackSpeed = attackFrequency;

        //navmesh
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        //get all slots into list
        attackSlots = GameObject.FindGameObjectsWithTag("SorcerorSlot");
        FindSlot();

        //turn off navmesh rotation instead sorceror will track player
        agent.updateRotation = false;

        //get aimspot
        aimSpot = target.GetComponent<PlayerController>().aimspot;

        //set health
        health = GetComponent<Health>();
    }

    private void Update()
    {
        //check for player death
        if(target.GetComponent<PlayerController>().dead == false && !dead)
        {
            if (attackMode)
            {
                Attack();
            }
            
            if (flee)
            {
                Flee();
            }
            else
            {
                GoToSlot();
            }

            //look at player
            transform.LookAt(target.transform);
        }
        else if(!dead)
        {
            animator.SetTrigger("Idle");
        }

        if (health.currentHealth <= 0 && dead == false)
        {
            //must turn this off for next wave
            sorcerorSlot.GetComponent<Sorceror_Slot>().isTaken = false;
            animator.SetTrigger("Dead");
            dead = true;
        }

        if (dead && deathTimer >= 1.0f && !deathDone)
        {
            GetComponent<CharacterSounds>().PlayDeathSound();

            explosion_fx.Play();
            weapon.SetActive(false);
            hood.SetActive(false);
            cloak.SetActive(false);
            healthbar.SetActive(false);
            shardBody.SetActive(true);
            body.SetActive(false);
            deathDone = true;
            Destroy(sorcerorRoot, 2.0f);
        }
        else if (dead && !deathDone)
            deathTimer += Time.deltaTime;

    }

    private void GoToSlot()
    {
        if (Vector3.Distance(target.transform.position, transform.position) <= 4)
        {
            flee = true;
        }
        agent.destination = sorcerorSlot.position;
        if (Vector3.Distance(target.transform.position, transform.position) <= 20 && Vector3.Distance(target.transform.position, transform.position) >= 2)
        {
            attackMode = true;
        }
    }

    private void Attack()
    {
        if (attackFrequency <= 0)
        {
            //check for distances and test to see where the player is 
            if (Vector3.Distance(target.transform.position, transform.position) <= 10 && Vector3.Distance(target.transform.position, transform.position) >= 2)
            {
                
                Debug.Log("sorcerorAttack");
                animator.SetTrigger("Attack");
                attackFrequency = attackSpeed;
            }
        }
        else
        {
            attackFrequency -= Time.deltaTime;
        }
        
        
        if(Vector3.Distance(target.transform.position, transform.position) <= 4)
        {
            flee = true;
            
        }
    }

    //event to be called on mage attack animation
    //shoots projectiles at player
    private void ShootProjectile()
    {
        GetComponent<CharacterSounds>().PlayAttackSound();
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

            //check if it is on navmesh
            NavMeshHit hit;
            if(NavMesh.SamplePosition(newPos, out hit, 5f, NavMesh.AllAreas))
            {
                //set the destination for the navmesh agent
                agent.SetDestination(hit.position);
            }
            

            
        }
    }
    
}
