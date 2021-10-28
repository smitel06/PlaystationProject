using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPrizes : MonoBehaviour
{
    [SerializeField] SpawnSystem spawnSystem;
    public bool canExitRoom;

    private void Update()
    {
        //check if all enemies are dead
        if(spawnSystem.finished)
        {
            //spawn middle prize
        }
    }
}
