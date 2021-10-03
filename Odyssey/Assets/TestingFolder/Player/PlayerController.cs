using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //use this script to control the player through input

    //Movement variables and components
    Rigidbody rb;
    //-------------------
    //combat variables
    bool attacking;
    public GameObject currentWeapon;
    float attackTime;
    float waitTime;

    //animator things
    Animator animator;
    float idleTimer;
    float idleSwitchWait;
    //randomly set idle
    [SerializeField] int randomIdle;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        attackTime = 0.5f;

        idleSwitchWait = 10.0f;
    }

    void FixedUpdate()
    {
        if(Input.GetAxis("HorizontalMovement") != 0 || Input.GetAxis("VerticalMovement") != 0)
        {
            movePlayer();
        }
        else
        {
            animator.SetBool("Moving", false);
            idleAnimation();
        }
        
        //
        //Attack();

    }

    private void Attack()
    {
        //if animation is not playing
        if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            attacking = false;
            //if x is pressed
            if (Input.GetButtonDown("Attack"))
            {
                //set time till we want hit to occur
                waitTime = attackTime + Time.time;

                rb.velocity = new Vector3(0, 0, 0);
                GetComponent<Animator>().SetTrigger("Attack");
            }
            else
                movePlayer();
        }
        else
            attacking = true;

        //stop hits from happening unless we want them to 
        if (attacking == true && waitTime < Time.time)
        {
            currentWeapon.GetComponent<weaponScript>().attackOn = true;

        }
        //else
        //    currentWeapon.GetComponent<weaponScript>().attackOn = false;
    }

    //move the player according to controller input
    void movePlayer()
    {

        animator.SetBool("Moving", true);
        // use this for animation velocity and blend tree
        float maxVelocity = 10; 
        
        //get inputs and magnitude
        Vector3 input = new Vector3(Input.GetAxis("HorizontalMovement"), 0, Input.GetAxis("VerticalMovement"));
        float inputMagnitude = input.magnitude;
        //get velocity
        float velocity = inputMagnitude * maxVelocity;

        //set velocity of the rigidbody this is what moves the character
        rb.velocity = (input * velocity);

        //rotate player in movement direction
        if (inputMagnitude > 0)
            rb.transform.rotation = Quaternion.LookRotation(input, rb.transform.up);

        //update animator
        if(velocity > 6.8f)
            animator.SetFloat("Blend", inputMagnitude);
        else
            animator.SetFloat("Blend", 0);
    }

    void idleAnimation()
    {
        idleTimer += Time.deltaTime;
        if (idleTimer > idleSwitchWait)
        {
            randomIdle = Random.Range(0, 5);
            animator.SetInteger("RandomIdleNum", randomIdle);
            idleTimer = 0;
        }
        
    }
}
