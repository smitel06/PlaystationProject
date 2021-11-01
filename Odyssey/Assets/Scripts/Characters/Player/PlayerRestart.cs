using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestart : MonoBehaviour
{
    //Use on death at restart of game
    //Will control beginning animation
    Animator animator;
    Vector3 move;
    bool startTimer;
    float timer;
    [SerializeField] float movementSpeed;
    [SerializeField] FollowCamera followCamera;
    [SerializeField] SmoothFollowCamera smoothFollowCamera;
    private void Start()
    {
        animator = GetComponent<Animator>();

        move = new Vector3(0, -0.5f) * movementSpeed;

        timer = 3.5f;
    }

    private void Update()
    {
        if(transform.position.y <= 0.52)
        {
            followCamera.enabled = false;
            smoothFollowCamera.enabled = true;
            animator.SetTrigger("HitGround");
            startTimer = true;
        }
        else if(!startTimer)
            transform.position += move * Time.deltaTime;

        if(startTimer && timer > 0)
        {
            //countdown timer
            timer -= Time.deltaTime;
        }
        else if(timer <= 0)
        {
            animator.applyRootMotion = false;
            GetComponent<PlayerController>().enabled = true;
            GetComponent<PlayerRestart>().enabled = false;
        }
    }
    

}
