using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            animator.SetTrigger("walk");
        }
        else if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
        }
        else if (Input.GetMouseButton(1))
        {
            animator.SetTrigger("block");
        }
        else
            animator.SetTrigger("idle");


        

    }
}
