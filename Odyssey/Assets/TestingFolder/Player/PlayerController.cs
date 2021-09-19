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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        attackTime = 0.5f;
    }

    void Update()
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
        if(attacking == true && waitTime < Time.time)
        {
            currentWeapon.GetComponent<weaponScript>().attackOn = true;

        }
        else
            currentWeapon.GetComponent<weaponScript>().attackOn = false;

    }

    //move the player according to controller input
    void movePlayer()
    {
        // use this for animation velocity and blend tree
        float maxVelocity = 17; 
        
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
        if(velocity > 6.8f)
            GetComponent<Animator>().SetFloat("Blend", inputMagnitude + 0.5f);
        else
            GetComponent<Animator>().SetFloat("Blend", 0);
    }
}
