using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseItem : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int coins;
    float distance;
    [SerializeField] float minDistance;
    [SerializeField] int cost;
    [SerializeField] GameObject popUp;
    bool canBuy;
    [SerializeField] GameObject appleHUD;
    [SerializeField] GameObject shopItem;
    bool shrink;
    [SerializeField] ParticleSystem collectEffect;
    
    

    private void Update()
    {
        if (shrink && shopItem.transform.localScale.x >= 0.01f)
        {
            shopItem.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if(shrink && shopItem.transform.localScale.x <= 0.01f)
        {
            shopItem.SetActive(false);
        }

        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < minDistance)
        {
            coins = player.GetComponent<PlayerCurrencies>().coins;
            popUp.SetActive(true);
            canBuy = true;
        }
        else
        {
            popUp.SetActive(false);
            canBuy = false;
        }

        if(canBuy && Input.GetButtonDown("Interact"))
        {
            if(cost == 250)
            {
                if(coins >= 250)
                {
                    if(!player.GetComponent<Buffs>().lifeBonus)
                    {
                        player.GetComponent<Buffs>().lifeBonus = true;
                        appleHUD.SetActive(true);

                        shrink = true;
                        
                        collectEffect.Play();
                        
                        player.GetComponent<PlayerCurrencies>().setCoins(-250);
                        popUp.SetActive(false);
                        Destroy(gameObject);
                    }
                }
            }
            else if (cost == 125)
            {
                if (coins >= 125)
                {
                    collectEffect.Play();
                    player.GetComponent<Health>().changeMaxValue(20);
                    player.GetComponent<PlayerCurrencies>().setCoins(-125);
                }
            }
        }
    }


}
