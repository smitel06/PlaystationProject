using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Transform entry;
    public int roomIndex;
    public bool transition;
    [SerializeField] SpawnSystem spawnSystem;
    public Prize middlePrize;
    bool spawn;
    public Prize nextRoomPrize;

    public void Setup()
    {
        if(middlePrize != null)
            middlePrize.nextRoomPrize = nextRoomPrize;
    }
    private void Update()
    {
        if (spawnSystem != null)
        {
            if (spawnSystem.finished && !spawn)
            {
                spawn = true;
                if(middlePrize != null)
                    middlePrize.SpawnPrize();
            }
        }
    }

}
