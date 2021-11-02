using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    bool shrink;
    int randomCoinAmount;
    public int minimumRange;
    public int maximumRange;
    [SerializeField] GameObject parent;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerCurrencies>().setCoins(randomCoinAmount);
            shrink = true;
        }

    }

    
    private void Update()
    {
        // Rotate the object around its local y axis so it appears to be spinning
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);

        //when collecting prize shrink
        if (shrink && transform.localScale.x >= 0.3f)
        {
            
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if(shrink)
        {
            Destroy(parent);
        }
    }

    public void SetRandomRange(int minRange, int maxRange)
    {
        minimumRange = minRange;
        maximumRange = maxRange;
        randomCoinAmount = Random.Range(minRange, maxRange);
    }
}
