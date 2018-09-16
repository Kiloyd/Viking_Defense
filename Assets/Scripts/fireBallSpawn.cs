using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBallSpawn : MonoBehaviour
{
    public GameObject fireball;
    public bool trigger;

    private GameObject Instance;

    private void Update()
    {
        if (trigger)
        {
            generateFireBall();
            trigger = false;
        }
    }

    void generateFireBall()
    {
        Instance = Instantiate<GameObject>(fireball, this.transform.position, this.transform.rotation);
    }

    public void setSpawnTrigger(bool fire)
    {
        trigger = fire;
    }
}
