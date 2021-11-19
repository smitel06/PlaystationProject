using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBeam : MonoBehaviour
{
    public int damage;
    [SerializeField] public static int hitCount;
    public int hitsTillDamage;

    private void OnParticleCollision(GameObject other)
    {
        if (hitCount >= hitsTillDamage)
        {
            if (other.tag == "Player")
            {
                other.GetComponent<Health>().TakeDamage(damage);

                hitCount = 0;
            }
        }
        else
            hitCount++;


    }

}
