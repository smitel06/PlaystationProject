using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardExplosion : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;
    public Rigidbody[] rigidbodies;
    
    

    void Awake()
    {

        rigidbodies = GetComponentsInChildren<Rigidbody>();
        Vector3 explosionPos = transform.position;
        
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
        dropCoin();
        Destroy(gameObject, 1.5f);
    }

    private void dropCoin()
    {
        foreach (Collider c in GetComponents<Collider>())
        {
            c.enabled = false;
        }

        GameObject coin = Instantiate(GameAssets.i.coinDrop, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity) as GameObject;
        //checks to see which random range to apply
        if(GetComponent<SorcerorController>() != null)
        {
            coin.GetComponent<CoinDrop>().SetRandomRange(5, 15);
        }
        else
            coin.GetComponent<CoinDrop>().SetRandomRange(10, 20);
    }

    private void OnDestroy()
    {
        
    }
}
