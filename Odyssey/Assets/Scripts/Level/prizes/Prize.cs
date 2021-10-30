using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prize : MonoBehaviour
{
    public bool middlePrize;
    bool prizeChosen;
    public Prize doorPrize1;
    public Prize doorPrize2 = null;
    public GameObject achievement;

    private void Start()
    {

        //0 = gem, 1 = key, 2 = heart, 3 = coins, 4 = buffs, 5 = grapes
        //middle prize won't have grapes
        if (!middlePrize)
        {
            prizeType = Random.Range(0, 6);
        }
        else
        {
            prizeType = Random.Range(0, 5);
        }



    }

    public int prizeType;
    [SerializeField] GameObject gem;
    [SerializeField] GameObject key;
    [SerializeField] GameObject heart;
    [SerializeField] GameObject grapes;
    [SerializeField] GameObject coin;
    [SerializeField] GameObject buff;
    GameObject selectedPrize;
    public Prize nextRoomPrize;
    public void SpawnPrize()
    {
        //select prize type and push to selected prize so we can manage
        if(prizeType == 0)
        {
            selectedPrize = gem;
        }
        else if(prizeType == 1)
        {
            selectedPrize = key;
        }
        else if (prizeType == 2)
        {
            selectedPrize = heart;
        }
        else if (prizeType == 3)
        {
            selectedPrize = coin;
        }
        else if (prizeType == 4)
        {
            selectedPrize = buff;
        }
        else if (prizeType == 5)
        {
            selectedPrize = grapes;
        }

        selectedPrize.SetActive(true);
        prizeChosen = true;
    }

    private void Update()
    {
        
    }
}

