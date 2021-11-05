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

    
    float timer;
    [SerializeField] bool AttackMode;

    //death functions
    bool dead;
    Health health;
    [SerializeField] GameObject healthbar;
    [SerializeField] GameObject shardBody;
    [SerializeField] GameObject Body;
    [SerializeField] GameObject weapon;
    [SerializeField] ParticleSystem deathExplosion;

    float deathTimer;
    bool deathDone;

    
    void Awake()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        

        //set health
        health = GetComponent<Health>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!target.GetComponent<PlayerController>().dead && !dead)
        {
            animator.SetBool("Idle", false);
            //distance from player will be used in a few ways
            currentDistanceFromPlayer = Vector3.Distance(transform.position, target.transform.position);

            UpdateAgent();
            UpdateAnimator();
            UpdateAttacking();
        }
        else if(!dead && target.GetComponent<PlayerController>().dead)
        {
            animator.SetBool("Idle", true);
        }
        

        if(health.currentHealth <= 0 && dead == false)
        {
            GetComponent<CharacterSounds>().PlayDeathSound();
            animator.SetTrigger("Dead");
            dead = true;
        }

        if (dead && deathTimer >= 0.5f && !deathDone)
        {
            deathExplosion.Play();
            AudioManager.instance.Play("U_C_Death");
            healthbar.SetActive(false);
            weapon.SetActive(false);
            shardBody.SetActive(true);
            Body.SetActive(false);
            
            Destroy(gameObject, 2.0f);
            deathDone = true;
        }
        else if(dead && !deathDone)
            deathTimer += Time.deltaTime;
        
    }

    
    private void UpdateAgent()
    {
        
        //check animator for attack animation
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            agent.enabled = false;
            animator.applyRootMotion = true;
            
        }
        else
        {
            agent.enabled = true;
            animator.applyRootMotion = false;
        }

        if (AttackMode)
        {

            UpdateAttacking();
        }
        
        
    }

    void UpdateAnimator()
    {
        float blend = 1.638454f;
        animator.SetFloat("Blend", blend);  
    }

    //update attacks
    void UpdateAttacking()
    {
        if (currentDistanceFromPlayer <= attackRange && currentDistanceFromPlayer > 2.5 && AttackMode)
        {
            agent.enabled = false;
            animator.SetBool("canAttack", true);
            GetComponent<CharacterSounds>().PlayAttackSound();
        }
        else
        {
            agent.enabled = true;
            animator.SetBool("canAttack", false);
            agent.destination = target.transform.position;
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

    


}
