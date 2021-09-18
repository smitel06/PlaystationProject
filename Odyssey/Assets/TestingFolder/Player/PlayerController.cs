using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //use this script to control the player through input

    //Movement variables and components
    Rigidbody rb;
    //-------------------

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //if animation is not playing
        if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            //if x is pressed
            if (Input.GetButtonDown("Attack"))
            {
                rb.velocity = new Vector3(0, 0, 0);
                GetComponent<Animator>().SetTrigger("Attack");
            }
            else
                movePlayer();
        }
        
    }

    //move the player according to controller input
    void movePlayer()
    {
        // use this for animation velocity and blend tree
        float maxVelocity = 15; 
        
        //get inputs and magnitude
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float inputMagnitude = input.magnitude;
        //get velocity
        float velocity = inputMagnitude * maxVelocity;

        //set velocity of the rigidbody this is what moves the character
        rb.velocity = (input * velocity);

        //rotate player in movement direction
        if (inputMagnitude > 0)
            rb.transform.rotation = Quaternion.LookRotation(input, rb.transform.up);

        //update animator
        if(velocity > 8.0f)
            GetComponent<Animator>().SetFloat("Blend", inputMagnitude + 0.5f);
        else
            GetComponent<Animator>().SetFloat("Blend", 0);
    }
}
