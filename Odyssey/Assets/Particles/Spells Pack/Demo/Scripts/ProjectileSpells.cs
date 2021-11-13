using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpells : MonoBehaviour {
    public GameObject ExplosionPrefab;
    public float DestroyExplosion = 4.0f;
    public float DestroyChildren = 2.0f;
    public Vector3 Velocity;
    [SerializeField] float moveSpeed;

    Rigidbody rb;

    public void Setup(Vector3 shootDirection, Vector3 position, GameObject summoner)
    {
        
        transform.position = position;
        Velocity = shootDirection;
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(Velocity));
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = Velocity * moveSpeed;
    }

    public static float GetAngleFromVectorFloat(Vector3 direction)
    {
        direction = direction.normalized;
        float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

    void Start () {
        
        

    }

    void OnCollisionEnter(Collision col)
    {
        var exp = Instantiate(ExplosionPrefab, transform.position, ExplosionPrefab.transform.rotation);
        Destroy(exp, DestroyExplosion);
        Transform child;
        child = transform.GetChild(0);
        transform.DetachChildren();
        Destroy(child.gameObject, DestroyChildren);
        Destroy(gameObject);
    }
}
