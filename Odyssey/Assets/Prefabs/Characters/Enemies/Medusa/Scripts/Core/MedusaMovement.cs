using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MedusaMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    MedusaController controller;
    Transform target;
    public bool canMove;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        controller = GetComponent<MedusaController>();
        target = controller.player;
        
    }

    

    private void Update()
    {
        if(canMove)
        {
            agent.enabled = true;
            agent.SetDestination(target.position);
        }
        else
        {
            agent.enabled = false;
        }
    }

    public void LookAtTarget(float rotationSpeed)
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = (controller.player.position - transform.position).normalized;
        targetDirection.y = 0;
        //create rotation we need
        Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
        Debug.DrawRay(transform.position, targetDirection);

        //use slerp for a smooth rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
}
