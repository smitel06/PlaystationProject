using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Transform entry;
    public int roomIndex;
    public bool transition;
    [SerializeField] SpawnSystem spawnSystem;
    [SerializeField] Prize middlePrize;
    bool spawn;

    private void Update()
    {
        if(spawnSystem.finished && !spawn)
        {
            spawn = true;
            middlePrize.SpawnPrize();
        }
    }

}
