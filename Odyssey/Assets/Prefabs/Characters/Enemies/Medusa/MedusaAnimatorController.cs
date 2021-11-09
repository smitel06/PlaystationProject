using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaAnimatorController : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateMovementAnimation();
    }

    void UpdateMovementAnimation()
    {
        Vector3 velocity = GetComponent<MedusaMovement>().agent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        animator.SetFloat("Blend", speed);

    }
}
