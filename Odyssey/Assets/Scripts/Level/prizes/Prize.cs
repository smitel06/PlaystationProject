using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prize : MonoBehaviour
{
    private void Start()
    {
        //0 = gem, 1 = key, 2 = heart, 3 = grapes, 4 = buffs, 5 = coins
        prizeType = Random.Range(0, 6);
        SpawnPrize();
    }

    public int prizeType;
    [SerializeField] GameObject gem;
    [SerializeField] GameObject key;
    [SerializeField] GameObject heart;
    [SerializeField] GameObject grapes;
    [SerializeField] GameObject coin;
    [SerializeField] GameObject buff;

    private void SpawnPrize()
    {
        

        if(prizeType == 0)
        {
            gem.SetActive(true);
        }
        else if(prizeType == 1)
        {
            key.SetActive(true);
        }
        else if (prizeType == 2)
        {
            heart.SetActive(true);
        }
        else if (prizeType == 3)
        {
            grapes.SetActive(true);
        }
        else if (prizeType == 4)
        {
            buff.SetActive(true);
        }
        else if (prizeType == 5)
        {
            coin.SetActive(true);
        }
    }

    
}

