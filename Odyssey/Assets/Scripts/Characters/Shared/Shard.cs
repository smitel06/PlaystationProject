using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;
    float timer;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 0.25)
        {
            rb.useGravity = true;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
