using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prize : MonoBehaviour
{
    private void Start()
    {
        SpawnPrize();
    }

    int prizeType;
    [SerializeField] GameObject gem;
    [SerializeField] GameObject key;
    [SerializeField] GameObject heart;
    [SerializeField] GameObject buff;
    private void SpawnPrize()
    {
        //0 = gem, 1 = key
        prizeType = 2;//Random.Range(0, 4);

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
            buff.SetActive(true);
        }
    }

    
}

