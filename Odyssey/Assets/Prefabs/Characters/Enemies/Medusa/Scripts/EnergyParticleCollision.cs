using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyParticleCollision : MonoBehaviour
{
    public float damage;
    public float timer;
    public float force;
    [SerializeField] ShieldBlast shieldBlast;

    private void Update()
    {
        if (timer <= 0)
            ExplosionDamage(transform.position, 4f);
        else
            timer -= Time.deltaTime;
    }
    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.gameObject.tag == "Player")
            {
                hitCollider.GetComponent<Health>().TakeDamage(damage);
                hitCollider.GetComponent<Rigidbody>().AddForce(hitCollider.gameObject.transform.position - transform.position * force, ForceMode.VelocityChange);
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
