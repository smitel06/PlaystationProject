using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestart : MonoBehaviour
{
    //Use on death at restart of game
    //Will control beginning animation
    Animator animator;
    Vector3 move;
    private void Start()
    {
        animator = GetComponent<Animator>();

        move = new Vector3(0, -0.5f) * 15f;
    }

    private void Update()
    {
        if(transform.position.y <= 0)
        {
            animator.SetTrigger("HitGround");
        }
        else
            transform.position += move * Time.deltaTime;
    }
    

}
