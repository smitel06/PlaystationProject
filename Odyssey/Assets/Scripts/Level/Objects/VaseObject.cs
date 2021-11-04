using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseObject : MonoBehaviour
{
    [SerializeField] Animator anim;
    int randomCoinAmount;
    int randomDrop;
    [SerializeField] ParticleSystem coinburst;

    private void OnEnable()
    {
        randomDrop = 1; // Random.Range(1, 5);
        randomCoinAmount = Random.Range(20, 35);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerWeapon")
        {
            anim.enabled = true;
            foreach (Collider c in GetComponents<Collider>())
            {
                c.enabled = false;
            }

            if (randomDrop < 2)
            {
                coinburst.Play();
                other.gameObject.GetComponent<PlayerWeapon>().player.GetComponent<PlayerCurrencies>().setCoins(randomCoinAmount);
            }

        }
    }

    //private void dropCoin()
    //{
        

    //    if (randomDrop < 2)
    //    {
    //        GameObject coin = Instantiate(GameAssets.i.coinDrop, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity) as GameObject;
    //        coin.GetComponent<CoinDrop>().SetRandomRange(20, 35);
    //    }
    //    foreach (Collider c in GetComponents<Collider>())
    //    {
    //        c.enabled = false;
    //    }

    //}
}
