using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // enemies collection
    GameObject[] enemies;
    //slots collection
    GameObject[] slots;
    void Start()
    {
        slots = GameObject.FindGameObjectsWithTag("Slots");
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //check if slot is taken then check closest enemy
    }
}
