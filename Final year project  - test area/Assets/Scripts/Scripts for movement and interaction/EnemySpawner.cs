using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // player\\
    public GameObject player; 
    // enemy prefabs \\
    public GameObject enemy; 
    // spawning \\
    public Transform[] spawnLocations;
    public float spawnTimer;
    public float spawnSpeed;
    private Transform spawnPoint;
    public int enemyCounter;
    public bool spawn;
    // level finish \\
    public FinishPoint finishPoint; 

    void Start()
    {
        spawnTimer = spawnSpeed;
        spawn = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer < spawnSpeed)
        {
            spawnTimer += Time.deltaTime;
        }

        if (spawnTimer >= spawnSpeed)
        {
            spawnTimer = 0f;
            SpawnRandom();
        }

        SpawnStop();
        AtLeast1Enemey();


    }

    public void SpawnRandom()
    {
        if (spawn)
        {
            spawnPoint = spawnLocations[Random.Range(0, spawnLocations.Length - 1)];
            if (enemyCounter <= 10)
            {
                Instantiate(enemy, spawnPoint.transform.position, transform.rotation);
                enemyCounter++;
            }

        }


    }  
    public void AtLeast1Enemey()
    {
        if (spawn)
        {
            if (enemyCounter <= 0)
            {
                Instantiate(enemy, spawnPoint.transform.position, transform.rotation);
                enemyCounter++;
            }

        }


    }


    public void SpawnStop()
    {
        if (finishPoint.levelFinish == true)
        {
            spawn = false; 
          
        }
    }


   
}
