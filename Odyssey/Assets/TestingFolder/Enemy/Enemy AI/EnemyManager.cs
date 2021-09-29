using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    // enemies collection
    GameObject[] enemies;
    //slots collection
    GameObject[] slots;
    void Start()
    {
        slots = GameObject.FindGameObjectsWithTag("Slot");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnemySlots();
    }

    private void UpdateEnemySlots()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //check if slot is taken then check closest enemy
        foreach (GameObject enemy in enemies)
        {
            //will be used to work out which slot is shortest
            GameObject closestSlot = null;

            if (!enemy.GetComponent<AIMover>().inSlot)
            {
                float distance = 0;
                float lowestDistance = 50;

                foreach (GameObject slot in slots)
                {

                    if (!slot.GetComponent<Slot>().isTaken)
                    {
                        //distance between enemy and slot
                        distance = Vector3.Distance(slot.transform.position, enemy.transform.position);

                        if (distance < lowestDistance)
                        {
                            lowestDistance = distance;
                            closestSlot = slot;
                        }
                    }
                }
                if (closestSlot == null)
                {
                    //do nothing
                }
                else
                {
                    enemy.GetComponent<AIMover>().slot = closestSlot;
                    enemy.GetComponent<AIMover>().inSlot = true;
                    closestSlot.GetComponent<Slot>().isTaken = true;
                }

            }
        }

        
    }
}
