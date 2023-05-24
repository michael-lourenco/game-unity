using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCard : MonoBehaviour
{
    public GameObject minion;
    private float timeBtwnSpawns;
    private int i = 0;

    private bool stopSpawning = false;

    private void Awake()
    {
        //timeBtwnSpawns = currentWave.TimeBeforeThisWave;
    }

    private void Start()
    {

    }
    private void Update()
    {
       /* if (stopSpawning)
        {
            return;
        }

        if (Time.time >= timeBtwnSpawns)
        {
            StartCoroutine(SpawnWave());
            IncWave();

            timeBtwnSpawns = Time.time + currentWave.TimeBeforeThisWave;
        }*/
    }

    public void SpawnCreature()
    {   
        Instantiate(minion, GameController.spawnPointMinionPlayer.transform.position, GameController.spawnPointMinionPlayer.transform.rotation);
    }
}