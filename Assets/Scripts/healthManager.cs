using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour
{
    [SerializeField]
    private engageArea[] area;
    private float damage;
    private float totalEnemy;
    [SerializeField]
    private float health;

    public float maximumHealth = 100;
    public float damage_per_second = 3;

    private void Start()
    {
        area = FindObjectsOfType<engageArea>();
        health = maximumHealth;
        damage = 0;
        totalEnemy = 0;
    }

    private void Update()
    {
        damageCount();
    }

    void damageCount()
    {
        totalEnemy = 0;
        for (int i = 0; i < area.Length; i++)
            totalEnemy += area[i].getEnemyCount();

        damage = totalEnemy * damage_per_second;
        health -= damage * Time.deltaTime;
    }

    public float getHealth()
    {
        return health / maximumHealth;
    }
}
