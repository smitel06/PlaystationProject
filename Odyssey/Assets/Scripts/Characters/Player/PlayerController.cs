using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //use this script to control the player through input

    //weapon things
    [SerializeField] Collider weaponCollider;

    //components
    Rigidbody rb;
    Animator animator;
    //common Variables
    Vector3 input;

    //stuff for iso control
    Vector3 forward, right;


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
    }

    void FixedUpdate()
    {

        movePlayer();
        checkAnimatorStates();

    }

    private void checkAnimatorStates()
    {
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

    void Update()
    {
        
        Attack();
        dash();

        
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

    

    void dash()
    {
        
        if (Input.GetButtonDown("Dash"))
        {
            input = new Vector3(Input.GetAxis("HorizontalMovement"), 0, Input.GetAxis("VerticalMovement"));
            float dashDistance = 4f;
            if(!Physics.Raycast(transform.position, input, dashDistance))
            {
                Vector3 beforeDashPosition = transform.position;
                transform.position += input * dashDistance;
            }
        }   
    }

    void Hit()
    {
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

    
}
