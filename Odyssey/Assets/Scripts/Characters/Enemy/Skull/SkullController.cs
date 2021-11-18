using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkullController : MonoBehaviour
{
    //materials
    [SerializeField] Material mainMaterial;
    [SerializeField] Material hurtMaterial;
    [SerializeField] float timeBetweenMaterials;
    [SerializeField] GameObject skullModel;

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

    float timeCanAttack;
    [SerializeField] float timeBetweenAttacks;

    //death animation stuff
    Health health;
    [SerializeField] GameObject fragmented_skull;
    [SerializeField] GameObject skull;
    [SerializeField] GameObject healthbar;
    bool coinDropped;

    

    private void Awake()
    {
        //set wander timer
        timer = wanderTimer;

        //navmesh
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();

        //get aimspot
        aimSpot = target.GetComponent<PlayerController>().aimspot;
    }

    void Update()
    {
        if (target.GetComponent<PlayerController>().dead == false)
        {
            CheckForDeath();

            if (attackMode)
            {
                StartCoroutine("Attacking");
            }


            CooldownAttack();
            CanAttack();
        }

        
    }

    private void CanAttack()
    {
        //can now attack after waitingf for pre attack animation
        if (canAttack && timeCanAttack <= 0.3f)
        {
            transform.position += shootDirection * moveSpeed * Time.deltaTime;
            timeCanAttack += Time.deltaTime;
        }
        else if (canAttack && timeCanAttack >= 0.3f)
        {
            GetComponent<Collider>().enabled = false;
            cooldownTimer = 0;
            timeCanAttack = 0;

            canAttack = false;
            attackMode = false;
        }
    }

    private void CheckForDeath()
    {
        if (health.currentHealth <= 0)
        {
            
            //turn off all bools
            attackMode = false;
            canAttack = false;
            cooldown = false;
            //swap models
            fragmented_skull.SetActive(true);
            healthbar.SetActive(false);
            skull.SetActive(false);
            dropCoin();
            Destroy(gameObject, 3);
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
            GetComponent<CharacterSounds>().PlayAttackSound();
            animator.SetTrigger("Attack");
            attackMode = false;
            shootDirection = (aimSpot.position - transform.position).normalized;
            yield return new WaitForSeconds(1);
            canAttack = true;

            yield return new WaitForSeconds(timeBetweenAttacks);
            attackMode = true;
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
                timeCanAttack = 0;
                other.GetComponent<Health>().TakeDamage(GetComponent<Damage>().currentDamage);
                moveDirection = (transform.position - other.transform.position).normalized;
                cooldown = true;
                canAttack = false;
            }
        }
    }

    private void dropCoin()
    {
        if (!coinDropped)
        {
            foreach (Collider c in GetComponents<Collider>())
            {
                c.enabled = false;
            }
     
            Debug.Log("SKULLCOIN");
            GameObject coin = Instantiate(GameAssets.i.coinDrop, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity) as GameObject;
            coin.GetComponent<CoinDrop>().SetRandomRange(1, 5);
            coinDropped = true;
        }
    }

    public void materialSwap()
    {
        StartCoroutine(swapMaterials());
    }

    IEnumerator swapMaterials()
    {
        var materials = skullModel.GetComponent<MeshRenderer>().materials;
        materials[0] = hurtMaterial;
        // reassign the materials to the renderer
        skullModel.GetComponent<MeshRenderer>().materials = materials;

        yield return new WaitForSeconds(timeBetweenMaterials);

        materials[0] = mainMaterial;

        skullModel.GetComponent<MeshRenderer>().materials = materials;
    }

    



}
