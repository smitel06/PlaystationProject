using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] SpawnPoint[] spawnPoints;
    [SerializeField] Room room;
    [SerializeField] List<GameObject> enemies = new List<GameObject>();

    int waveCounter;
    int spawnPointIndex;
    int randomEnemyType;
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
            randomEnemyType = Random.Range(1, 4);
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
        //Setup room depending on index
        if(room.roomIndex == 1)
        {
            if (waveCounter != 2 && enemies.Count == 0)
            {
                spawnPointIndex = 0;
                
                SpawnEnemies();
            }
        }
    }

    void SpawnEnemies()
    {
        
        //push enemies into wave
        if(randomEnemyType == 1)
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
