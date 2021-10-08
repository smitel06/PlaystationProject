﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //use this script to control the player through input

    //components
    Rigidbody rb;
    Animator animator;
    //common Variables
    Vector3 input;
    //animator things

    float idleTimer;
    float idleSwitchWait;
    //randomly set idle
    [SerializeField] int randomIdle;

    //bool
    public bool recievingForce;

    
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        idleSwitchWait = 10.0f;
    }

    void FixedUpdate()
    {
        //if(!recievingForce)
        //    rb.velocity = new Vector3(0, 0, 0);
        
        movePlayer();

        if (animator.GetCurrentAnimatorStateInfo(2).IsName("hit1") || this.animator.GetCurrentAnimatorStateInfo(2).IsName("hit2") || this.animator.GetCurrentAnimatorStateInfo(2).IsName("hit1_continued"))
        {
            animator.SetLayerWeight(animator.GetLayerIndex("Base"), 0);
            animator.SetLayerWeight(1, 1);
            animator.SetLayerWeight(2, 1);
            float indexOfThing = animator.GetLayerWeight(0);
            Debug.Log(indexOfThing);
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
            input = new Vector3(Input.GetAxisRaw("HorizontalMovement"), 0, Input.GetAxisRaw("VerticalMovement"));
            // use this for animation velocity and blend tree
            float maxVelocity = 5.737815f;
            float inputMagnitude = input.magnitude;
            //get velocity
            float velocity = inputMagnitude * maxVelocity;

            //set velocity of the rigidbody this is what moves the character
            rb.velocity = (input * velocity);

            //rotate player in movement direction
            if (inputMagnitude > 0.1)
            {
                rb.transform.rotation = Quaternion.LookRotation(input, rb.transform.up);
                animator.SetFloat("Blend", maxVelocity * inputMagnitude);
            }
            else
            {
                animator.SetFloat("Blend", 0);
            }


            }
        else
        {
            animator.SetBool("Moving", false);
            idleAnimation();
        }

        
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

    void dash()
    {
        
        if (Input.GetButtonDown("Dash"))
        {
            input = new Vector3(Input.GetAxis("HorizontalMovement"), 0, Input.GetAxis("VerticalMovement"));
            float dashDistance = 10f;
            if(!Physics.Raycast(transform.position, input, dashDistance))
            {
                Vector3 beforeDashPosition = transform.position;
                transform.position += input * dashDistance;
            }
        }   
    }

    void Hit()
    {
        //check for enemies 
        Debug.Log("hit");
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
