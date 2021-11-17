using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour
{
    //use this to activate bool for attack later
    [SerializeField] MedusaCombat combat;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //facing player
            combat.canShardAttack = true;
        }
    }
}
