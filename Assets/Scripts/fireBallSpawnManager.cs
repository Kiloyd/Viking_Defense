using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBallSpawnManager : MonoBehaviour
{
    public float generatePeriod = 1f;

    [SerializeField]
    private fireBallSpawn[] spawn;
    private float counting;

    private void Start()
    {
        spawn = FindObjectsOfType<fireBallSpawn>();
        counting = 0;
    }

    private void Update()
    {
        counting += Time.deltaTime;

        if(counting >= generatePeriod)
        {
            triggerFireBall();
            counting = 0;
        }
    }

    void triggerFireBall()
    {
        int randomNum;
        randomNum = (int)Random.Range(0, spawn.Length);

        spawn[randomNum].setSpawnTrigger(true);
    }
}
