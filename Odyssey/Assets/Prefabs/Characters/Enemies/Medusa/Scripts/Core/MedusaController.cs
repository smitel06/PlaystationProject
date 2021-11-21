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
    [SerializeField] GameObject medusaHUD;
    bool start;
    bool dead;

    private void Start()
    {
        //set up variables
        combat = GetComponent<MedusaCombat>();
        movement = GetComponent<MedusaMovement>();
        animatorController = GetComponent<MedusaAnimatorController>(); 
    }

    //setup battle start when player is close enough
    private void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) <= 10 && !start)
        {
            StartBattleSequence();
            start = true;
        }

        if(GetComponent<Health>().currentHealth <= 0 && !dead)
        {
            //you die medusas
            animatorController.animator.enabled = true;
            
            GetComponent<CharacterSounds>().PlayDeathSound();
            animatorController.animator.SetTrigger("dead");
            combat.enabled = false;
            movement.canMove = false;
            movement.enabled = false;
            dead = true;
        }
    }

    //Call this function when battle is starting
    void StartBattleSequence()
    {
        medusaHUD.SetActive(true);
        movement.canMove = true;
        combat.attackType = 4;

    }

    public void Dead()
    {
        animatorController.enabled = false;
    }
}
