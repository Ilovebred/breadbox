using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemybigPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    private bool enemybig = true;
    public int waveNumber = 1;
    

    // Start is called before the first frame update
    void Start()
    {
      //Controls enemy spawns
      //spawns regular enemies
      SpawnEnemyWave(waveNumber);
      Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
      //the enemy count or number of enemies spawned
      enemyCount = FindObjectsOfType<Enemy>().Length;

      if(enemyCount == 0) 
      //Spawns power ups
      {
        enemybig = true;
        waveNumber++;
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
      }

      if(enemyCount > 5 && enemybig)
      //spawns Hard enemys
      {
        for(int i = 0; i < enemyCount-5; i++ ){Instantiate(enemybigPrefab, GenerateSpawnPosition(), enemybigPrefab.transform.rotation);}
        enemybig = false;
      }

      
      

      



    }
    //number of enemies per wave

    void SpawnEnemyWave(int enemiesToSpawn)
    {
      for(int i = 0; i < enemiesToSpawn; i++ )
      {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
      }



    }


    private Vector3 GenerateSpawnPosition()
    //where enemies spawn
    {
       float SpawnPosX = Random.Range(-spawnRange, spawnRange);
       float SpawnPosZ = Random.Range(-spawnRange, spawnRange);

       Vector3 randomPos = new Vector3(SpawnPosX, 0, SpawnPosZ);

       return randomPos;
    }
}
