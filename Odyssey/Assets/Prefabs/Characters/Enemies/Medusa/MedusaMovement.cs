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
        canMove = true;
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
}
