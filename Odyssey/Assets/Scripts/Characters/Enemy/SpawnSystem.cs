using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] SpawnPoint[] spawnPoints;
    [SerializeField] Room room;
    [SerializeField] List<GameObject> enemies = new List<GameObject>();
    public bool finished;

    int waveCounter;
    int spawnPointIndex;
    int randomEnemyType;
    int randomEnemyType2;
    int numberOfWaves;
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

        if(room.roomIndex == 1)
        {
            numberOfWaves = 2;
            randomEnemyType = Random.Range(1, 4);
        }
        else if(room.roomIndex > 1 && room.roomIndex <= 7)
        {
            //Room 2 > 7 = two enemies(between 2 to 4 waves)
            numberOfWaves = Random.Range(2, 5);
            //set two enemies
            randomEnemyType = Random.Range(1, 4);
            randomEnemyType2 = Random.Range(1, 4);
        }
        else if(room.roomIndex > 8)
        {
            //Room 8 > 10 = 3 enemies(between 3 to 7 waves) or introducing harder enemies
            numberOfWaves = Random.Range(3, 8);
        }


    }

    private void Update()
    {
        //calculate waves
        CalculateWave();

        //check enemies list to set it to empty if we need to
        checkEnemies();
    }
    void LoadInEnemies()
    {
        cyclops = GameAssets.i.enemyCyclops;
        sorceror = GameAssets.i.enemySorceror;
        skull = GameAssets.i.enemySkull;
    }

    void CalculateWave()
    {
        if (waveCounter != numberOfWaves && enemies.Count == 0)
        {
            spawnPointIndex = 0;   
            SpawnEnemies();
        }
        else if(waveCounter == numberOfWaves && enemies.Count == 0)
        {
            finished = true;
        }
       
    }

    void SpawnEnemies()
    {
        if(room.roomIndex > 1 && room.roomIndex <= 7)
        {
            //pick a type before each wave
            int randomPickType = Random.Range(0, 2);
            if(randomPickType == 0)
            {
                //swap the ints over if there is a 0
                int temp = randomEnemyType;
                randomEnemyType = randomEnemyType2;
                randomEnemyType2 = temp;
            }
        }
        else if (room.roomIndex > 8)
        {
            //completely random for each wave
            randomEnemyType = Random.Range(1, 4);
        }

        //push enemies into wave
        if (randomEnemyType == 1)
        {
            //push in two cyclops to wave
            enemies.Add(Instantiate(cyclops, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation));
                
            spawnPointIndex++;

            enemies.Add(Instantiate(cyclops, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation));

            
            waveCounter++;
        }
            
        if (randomEnemyType == 2)
        {
            //push in 5 skulls to wave
            //will do for loop later
            enemies.Add(Instantiate(skull, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation));

            spawnPointIndex++;

            enemies.Add(Instantiate(skull, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation));
                
            spawnPointIndex++;

            enemies.Add(Instantiate(skull, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation));

            spawnPointIndex++;

            enemies.Add(Instantiate(skull, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation));

            spawnPointIndex++;

            enemies.Add(Instantiate(skull, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation));

            
            waveCounter++;
        }

            
        if (randomEnemyType == 3)
        {
            //push in three sorcerors to wave
            enemies.Add(Instantiate(sorceror, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation));
                
            spawnPointIndex++;

            enemies.Add(Instantiate(sorceror, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation));

            spawnPointIndex++;

            enemies.Add(Instantiate(sorceror, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.localRotation));

            
            waveCounter++;
        }
        
    }

    void checkEnemies()
    {
        //use a for loop check for nulls set to delete if there is
        foreach(GameObject enemy in enemies)
        {
            if(enemy == null)
            {
                enemies.Remove(enemy);
                return;
            }
        }
    }
}
