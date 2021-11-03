using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseItem : MonoBehaviour
{
    [SerializeField] GameObject player;
    int coins;
    float distance;
    [SerializeField] float minDistance;
    [SerializeField] int cost;
    [SerializeField] GameObject popUp;
    Buffs buffs;
    bool canBuy;
    
    void Start()
    {
        coins = player.GetComponent<PlayerCurrencies>().coins;
        buffs = player.GetComponent<Buffs>();
    }

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < minDistance)
        {
            popUp.SetActive(true);
            canBuy = true;
        }
        else
        {
            popUp.SetActive(false);
            canBuy = false;
        }

        if(canBuy && Input.GetAxis("Interact") > 0)
        {
            if(cost == 250)
            {
                if(coins >= 250)
                {
                    if(!buffs.lifeBonus)
                    {
                        buffs.lifeBonus = true;
                        player.GetComponent<PlayerCurrencies>().setCoins(-250);
                    }
                }
            }
        }
    }


}
