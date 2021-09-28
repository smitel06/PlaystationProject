using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMover : MonoBehaviour
{
    GameObject target;
    NavMeshAgent agent;
    //how far apart each enemy should be
    public float spaceBetween = 1.5f;
    //array to hold all enemies currently on screen
    GameObject[] enemies;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //check for enemies and add them to the array
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemies)
        {
            if(enemy != gameObject)
            {
                float distance = Vector3.Distance(enemy.transform.position, this.transform.position);

                if(distance <= spaceBetween)
                {
                    agent.destination = this.transform.position;
                }
                else
                {
                    agent.destination = target.transform.position;
                }
            }
        }
        
    }
}
