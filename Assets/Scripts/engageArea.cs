using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engageArea : MonoBehaviour
{
    [SerializeField]
    private Collider collider;
    [SerializeField]
    private List<GameObject> engageEnemyList;
    [SerializeField]
    private int enemyCount;

    private void Start()
    {
        collider = GetComponent<Collider>();
        enemyCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
            engageEnemyList.Add(other.gameObject);
    }
    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "enemy")
            enemyCount--;
    }
    */
    public int getEnemyCount()
    {
        return enemyCount = engageEnemyList.Count;
    }

    public List<GameObject> getEnemyList()
    {
        return engageEnemyList;
    }
}
