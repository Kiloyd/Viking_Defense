using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public Transform targetForEnemy;
    public float movementSpeed = 0.05f;

    private Vector3 start_position;
    private GameObject enemyInstance;
 
    [SerializeField]
    private bool spawnTrigger;

    private void Start()
    {
        start_position = this.transform.position;
    }

    void GenerateEnemy()
    {
        enemyInstance = Instantiate<GameObject>(enemy, this.transform);
        enemyInstance.GetComponent<enemy>().setTargetAndSpeed(targetForEnemy, movementSpeed);
    }

    private void Update()
    {
        if (spawnTrigger)
        {
            GenerateEnemy();
            spawnTrigger = false;
        }

    }

    public void setSpawnTrigger(bool trigger)
    {
        spawnTrigger = trigger;
    }
}
