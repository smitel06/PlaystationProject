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

    

   

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        idleSwitchWait = 10.0f;
    }

    void Update()
    {
        //get inputs and magnitude
        input = new Vector3(Input.GetAxis("HorizontalMovement"), 0, Input.GetAxis("VerticalMovement"));
        dash();
        movePlayer();
    }

    private void Attack()
    {
        
    }

    //move the player according to controller input
    void movePlayer()
    {
        if (Input.GetAxis("HorizontalMovement") != 0 || Input.GetAxis("VerticalMovement") != 0)
        {
            animator.SetBool("Moving", true);
            // use this for animation velocity and blend tree
            float maxVelocity = 10;
            float inputMagnitude = input.magnitude;
            //get velocity
            float velocity = inputMagnitude * maxVelocity;

            //set velocity of the rigidbody this is what moves the character
            rb.velocity = (input * velocity);

            //rotate player in movement direction
            if (inputMagnitude > 0)
                rb.transform.rotation = Quaternion.LookRotation(input, rb.transform.up);

           animator.SetFloat("Blend", inputMagnitude);
            
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
            randomIdle = Random.Range(0, 3);
            animator.SetInteger("RandomIdleNum", randomIdle);
            idleTimer = 0;
        }
    }

    void dash()
    {
        if (Input.GetButtonDown("Dash"))
        {
            float dashDistance = 10f;
            if(!Physics.Raycast(transform.position, input, dashDistance))
            {
                Vector3 beforeDashPosition = transform.position;
                transform.position += input * dashDistance;
            }
        }   
    }
}
