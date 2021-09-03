using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    float horInput;
    float verInput;
    public float movementSpeed;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(horInput, 0f, verInput);
        Vector3 moveDestination = transform.position + movement;
        GetComponent<NavMeshAgent>().destination = moveDestination;

        if (Input.GetKey(KeyCode.W))
        {
            verInput = movementSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verInput = -movementSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horInput = movementSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horInput = -movementSpeed;
        }
        else
        {
            horInput = 0;
            verInput = 0;
        }
        
    }
}
