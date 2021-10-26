using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] SpawnPoint[] spawnPoints;
    [SerializeField] Room room;
    
    
    int enemyTypes;
    int spawnPointIndex;
    int randomEnemyType;
    GameObject cyclops;
    GameObject sorceror;
    GameObject skull;

    private void OnEnable()
    {
        //fill the array with spawn points, enemies will be spawned here
        spawnPoints = this.GetComponentsInChildren<SpawnPoint>();

        
        spawnPointIndex = 0;

        //spawn some enemies
        LoadInEnemies();
        CalculateWave();
    }


    void LoadInEnemies()
    {
        cyclops = GameAssets.i.enemyCyclops;
        sorceror = GameAssets.i.enemySorceror;
        skull = GameAssets.i.enemySkull;
    }

    void CalculateWave()
    {
        //Setup room depending on index
        if(room.roomIndex == 1)
        {
            enemyTypes = 1;
            
            SpawnEnemies(enemyTypes);
        }
    }

    void SpawnEnemies(int enemyTypes)
    {
        for(int i = 0; i < enemyTypes; i++)
        {
            randomEnemyType = Random.Range(1, 4);

            //push enemies into wave
            if(randomEnemyType == 1)
            {
                //push in two cyclops to wave
                Instantiate(cyclops, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation);
                
                spawnPointIndex++;

                Instantiate(cyclops, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation);
                
                spawnPointIndex++;
            }
            
            if (randomEnemyType == 2)
            {
                //push in 5 skulls to wave
                //will do for loop later
                Instantiate(skull, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation);
                
                spawnPointIndex++;

                Instantiate(skull, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation);
                
                spawnPointIndex++;

                Instantiate(skull, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation);
                
                spawnPointIndex++;

                Instantiate(skull, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation);
                
                spawnPointIndex++;

                Instantiate(skull, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation);
                
                spawnPointIndex++;

            }

            
            if (randomEnemyType == 3)
            {
                //push in three sorcerors to wave
                Instantiate(sorceror, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation);
                
                spawnPointIndex++;

                Instantiate(sorceror, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation);
                
                spawnPointIndex++;

                Instantiate(sorceror, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation);
                
                spawnPointIndex++;
            }
        }
    }
}
