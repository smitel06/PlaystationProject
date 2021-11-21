using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseObject : MonoBehaviour
{
    [SerializeField] GameObject smashedVase;
    [SerializeField] ParticleSystem coins;
    [SerializeField] ParticleSystem sparkles;
    int randomCoinChance;

    

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerWeapon")
        {
            randomCoinChance = Random.Range(0, 4);
            if(randomCoinChance == 2)
            {
                int randomCoin = Random.Range(5 , 15);
                other.gameObject.GetComponent<PlayerWeapon>().player.GetComponent<PlayerCurrencies>().setCoins(randomCoin);
                coins.Play();
                sparkles.Play();
                AudioManager.instance.Play("U_O_VaseCoin1");
            }

            
            GetComponent<MeshRenderer>().enabled = false;
            smashedVase.SetActive(true);
            AudioManager.instance.Play("U_O_VaseBreak2");
            foreach (Collider c in GetComponents<Collider>())
            {
                c.enabled = false;
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
