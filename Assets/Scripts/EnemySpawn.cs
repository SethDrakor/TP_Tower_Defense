using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour 
{

    public Transform[] spawnPoints;
    public GameObject enemy;
    public float spawnTime = 5f;
    public float spawnDelay = 3f; 

    void Start () {
        InvokeRepeating ("addEnemy", spawnDelay, spawnTime);
    }

    void addEnemy() 
    {
        if(spawnPoints.Length > 0)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
}