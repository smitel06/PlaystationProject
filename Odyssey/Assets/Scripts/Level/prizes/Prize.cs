using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prize : MonoBehaviour
{
    public int prizeType;
    [SerializeField] GameObject gem;
    [SerializeField] GameObject key;
    [SerializeField] GameObject heart;
    [SerializeField] GameObject grapes;
    [SerializeField] GameObject coin;
    [SerializeField] GameObject buff;
    public GameObject lotus;

    public RoomTransitions roomTransitions;
    GameObject selectedPrize;
    public Prize nextRoomPrize;
    public bool middlePrize;
    bool prizeChosen;
    public Prize doorPrize1;
    public Prize doorPrize2 = null;
    public Prize doorPrize3 = null;
    public AchievementReferences achievementReferences;
    bool canCollect;

    private void Start()
    {
        player = GameObject.Find("Player");
        
        //0 = gem, 1 = key, 2 = heart, 3 = coins, 4 = buffs, 5 = grapes
        //middle prize won't have grapes
        if (!middlePrize)
        {
            prizeType = Random.Range(0, 5);
        }
        else
        {
            prizeType = Random.Range(0, 4);
        }



    }

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
            selectedPrize = grapes;
        }
        else if (prizeType == 5)
        {
            selectedPrize = buff;
        }

        selectedPrize.SetActive(true);
        prizeChosen = true;
    }

    
    public GameObject player;
    [SerializeField] GameObject popUp;
    private void Update()
    {
        ActivatePrize();
    }

    bool finished;
    private void ActivatePrize()
    {

        if (selectedPrize != null)
        {
            if (canCollect)
            {
                if(!finished)
                    popUp.SetActive(true);

                //now check for input
                if (Input.GetButtonDown("Interact"))
                {
                    finished = true;
                    popUp.SetActive(false);
                    player.GetComponent<PlayerController>().pausePlayer = true;
                    selectedPrize.SendMessage("Collect");
                }
            }
            else
            {
                popUp.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            canCollect = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            canCollect = false;
    }
}

