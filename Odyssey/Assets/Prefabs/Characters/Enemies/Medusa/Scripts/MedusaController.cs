using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaController : MonoBehaviour
{
    //the target
    public Transform player;
    public MedusaCombat combat;
    public MedusaMovement movement;
    public MedusaAnimatorController animatorController;
    [SerializeField] Transform entry;

    private void Start()
    {
        //set up variables
        combat = GetComponent<MedusaCombat>();
        movement = GetComponent<MedusaMovement>();
        animatorController = GetComponent<MedusaAnimatorController>();
        
    }


}
