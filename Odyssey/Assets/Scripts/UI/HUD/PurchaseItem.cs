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
    
    

    private void Update()
    {
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
                    player.GetComponent<Health>().changeMaxValue(20);
                    player.GetComponent<PlayerCurrencies>().setCoins(-125);
                }
            }
        }
    }


}
