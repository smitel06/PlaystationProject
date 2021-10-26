using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 shootDirection;
    [SerializeField] float moveSpeed = 0;
    float timer;
    
    [SerializeField] ParticleSystem darkOrbParticle;
    bool moveParticle = true;
    [SerializeField] GameObject sorceror;
    public void Setup(Vector3 shootDirection, Vector3 position, GameObject summoner)
    {
        timer = 3.5f;
        sorceror = summoner;
        transform.position = position;
        this.shootDirection = shootDirection;
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(shootDirection));
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        if (moveParticle)
        {
            transform.position += shootDirection * moveSpeed * Time.deltaTime;
        }

        if (timer <= 0)
        {
            darkOrbParticle.Stop();
        }
        else
            timer -= Time.deltaTime;
    }

    public static float GetAngleFromVectorFloat(Vector3 direction)
    {
        direction = direction.normalized;
        float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            other.GetComponent<Health>().TakeDamage(sorceror.GetComponent<Damage>().currentDamage);
            GetComponent<Collider>().enabled = false;
        }

        darkOrbParticle.Stop();
        
        moveParticle = false;
        
    }
}
