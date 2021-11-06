using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    //use this script to control the player through input

    //death transition stuff
    [SerializeField] GameObject deathHud;
    Color imageColor;
    public float transitionSpeed;

    //weapon things
    [SerializeField] Collider weaponCollider;
    
    //components
    Rigidbody rb;
    Animator animator;
    //common Variables
    Vector3 input;

    //stuff for iso control
    Vector3 forward, right;

    //health and death stuff
    Health health;
    public bool dead;
    int randomDeath;

    //references for other scripts
    public Transform aimspot;

    

    [SerializeField] ParticleSystem bloodSplatter;
    [SerializeField] ParticleSystem deathExplosion;
    bool reviving;
    [SerializeField] bool godMode;
    public bool pausePlayer;
    public void damageSound()
    {
        //insert damage sound here
    }

   
    private void Start()
    {
        
        //setup the components we need
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        //set forward vector to camera
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        //set right vector
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        //collect health component from player
        health = GetComponent<Health>();

        if (godMode)
        {
            health.changeMaxValue(99999);
            health.currentHealth = 99999;
            GetComponent<Damage>().currentDamage = 1000;
            GetComponent<PlayerCurrencies>().setCoins(10000);
        }

    }

    void FixedUpdate()
    {
        if (!dead && !pausePlayer)
        {
            movePlayer();
            checkAnimatorStates();
        }

    }

    

    void Update()
    {
        IsPlayerDead();

        if (!dead)
        {
            Attack();
        }


    }

    private void IsPlayerDead()
    {
        if (health.currentHealth <= 0 )
        {
            GetComponent<CharacterSounds>().PlayDeathSound();
            //check health if below zero you die
            deathExplosion.Play();
            dead = true;
            //stop moving you are dead
            rb.velocity = new Vector3(0, 0, 0);
            //each number corrosponds to a death animation
            randomDeath = Random.Range(0, 4);
            animator.SetInteger("RandomDeath", randomDeath);
            
            animator.SetLayerWeight(animator.GetLayerIndex("Base"), 1);
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(2, 0);

            if (GetComponent<Buffs>().lifeBonus)
            {
                animator.SetTrigger("Dead");
                StartCoroutine(Revive());
                
            }
            else if(!GetComponent<Buffs>().lifeBonus && !reviving)
            {
                animator.SetTrigger("Dead");
                deathHud.SetActive(true);
            }

           
        }
    }

    IEnumerator Revive()
    {
        reviving = true; 
        GetComponent<Buffs>().lifeBonus = false;

        yield return new WaitForSeconds(5f);
        deathExplosion.Stop();
        animator.SetTrigger("Revive");
        health.currentHealth = health.maxHealth;
        yield return new WaitForSeconds(2f);
        dead = false;
        reviving = false;

    }

    private void checkAnimatorStates()
    {
        //checks what is currently playing on animator controller
        if (animator.GetCurrentAnimatorStateInfo(2).IsName("hit1") || this.animator.GetCurrentAnimatorStateInfo(2).IsName("hit2") || this.animator.GetCurrentAnimatorStateInfo(2).IsName("hit1_continued"))
        {
            animator.SetLayerWeight(animator.GetLayerIndex("Base"), 0);
            animator.SetLayerWeight(1, 1);
            animator.SetLayerWeight(2, 1);
            float indexOfThing = animator.GetLayerWeight(0);

        }
        else
        {
            animator.SetLayerWeight(animator.GetLayerIndex("Base"), 1);
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(2, 0);
        }
    }

    private void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            //layer weights control layers 
            animator.SetLayerWeight(animator.GetLayerIndex("Base"), 0);
            animator.SetLayerWeight(1, 1);
            animator.SetLayerWeight(2, 1);

            animator.SetTrigger("Attack");
            
            
        }
        

    }

    //move the player according to controller input
    void movePlayer()
    {
        
        if (Input.GetAxisRaw("HorizontalMovement") > 0.1 || Input.GetAxisRaw("VerticalMovement") != 0.1)
        {
            //get input for magnitude
            input = new Vector3(Input.GetAxisRaw("HorizontalMovement"), 0, Input.GetAxisRaw("VerticalMovement"));
            
            // use this for animation velocity and blend tree
            float maxVelocity = 5.737815f;
            float inputMagnitude = input.magnitude;
            //get velocity
            float velocity = inputMagnitude * maxVelocity;

            //things for iso movement
            Vector3 rightMovement = right * velocity * Time.deltaTime * Input.GetAxisRaw("HorizontalMovement");
            Vector3 upMovement = forward * velocity * Time.deltaTime * Input.GetAxisRaw("VerticalMovement");
            Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

            

            //set velocity of the rigidbody this is what moves the character
            rb.velocity = (heading * velocity);

            //rotate player in movement direction
            if (inputMagnitude > 0.1)
            {
                animator.SetTrigger("Moving");
                rb.transform.rotation = Quaternion.LookRotation(heading, rb.transform.up);
                animator.SetFloat("Blend", maxVelocity * inputMagnitude);
            }
            else
            {
                animator.SetFloat("Blend", 0);
            }
        }
        else
        {
            animator.SetFloat("Blend", 0);

        }

    }

    

    

    void Hit()
    {
        GetComponent<CharacterSounds>().PlayAttackSound();
        weaponCollider.enabled = true;
    }

    void FinishedAttacking()
    {
        weaponCollider.enabled = false;
    }


    public void FootL()
    {
        //footsteps???
    }

    public void FootR()
    {
        //footsteps???
    }

    //shield bash??
    void BlockAttack()
    {
        if (Input.GetButtonDown("Block"))
        {
            Debug.Log("blocking");
            animator.SetTrigger("Block");
        }
    }

    void BloodOn()
    {
        //blood particle effect show when hit
        bloodSplatter.Play();
    }

    void BloodOff()
    {
        //blood particle effect show when hit
        bloodSplatter.Stop();
    }

    
    
}
