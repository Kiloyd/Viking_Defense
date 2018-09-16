using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnManager : MonoBehaviour
{
    public float generatePeriod = 1f;

    [SerializeField]
    private enemySpawn[] spawnArray;
    private float counting;

    private void Start()
    {
        spawnArray = FindObjectsOfType<enemySpawn>();
        counting = 0;
    }

    private void Update()
    {
        counting += Time.deltaTime;

        if(counting >= generatePeriod)
        {
            generateEnemy();
            counting = 0;
        }

    }

    void generateEnemy()
    {
        int randomNum;
        randomNum = (int)Random.Range(0, spawnArray.Length);

        spawnArray[randomNum].setSpawnTrigger(true);
    }
}
