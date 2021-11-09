using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaController : MonoBehaviour
{
    //the target
    public Transform player;
    MedusaCombat combat;
    MedusaMovement movement;

    private void Start()
    {
        //set up variables
        
        combat = GetComponent<MedusaCombat>();
        movement = GetComponent<MedusaMovement>();
        movement.canMove = true;
    }
}
