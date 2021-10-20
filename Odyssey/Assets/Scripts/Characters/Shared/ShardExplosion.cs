using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardExplosion : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;
    public Rigidbody[] rigidbodies;
    

    void Start()
    {

        rigidbodies = GetComponentsInChildren<Rigidbody>();
        Vector3 explosionPos = transform.position;
        
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }

        Destroy(gameObject, 1.5f);
    }
}
