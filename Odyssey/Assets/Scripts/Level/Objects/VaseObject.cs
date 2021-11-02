using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseObject : MonoBehaviour
{
    [SerializeField] Animator anim;
    int randomDrop;

    private void OnEnable()
    {
        randomDrop = Random.Range(1, 5);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerWeapon")
        {
            anim.enabled = true;
            dropCoin();
        }
    }

    private void dropCoin()
    {
        

        if (randomDrop < 2)
        {
            GameObject coin = Instantiate(GameAssets.i.coinDrop, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity) as GameObject;
            coin.GetComponent<CoinDrop>().SetRandomRange(20, 35);
        }
        foreach (Collider c in GetComponents<Collider>())
        {
            c.enabled = false;
        }

    }
}
