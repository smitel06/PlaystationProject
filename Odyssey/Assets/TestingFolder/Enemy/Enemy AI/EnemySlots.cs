﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlots : MonoBehaviour
{
    // Controls the slots enemies go to

    Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;
    }

    
}
