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
        movePlayer();
    }

    //move the player according to controller input
    void movePlayer()
    {
        // use this for animation velocity and blend tree
        float maxVelocity = 5; 
        
        //get inputs and magnitude
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float inputMagnitude = input.magnitude;
        //get velocity
        float velocity = inputMagnitude * maxVelocity;

        //set velocity of the rigidbody this is what moves the character
        rb.velocity = (input * velocity);

    }
}
