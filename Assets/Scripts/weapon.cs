using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField]
    private Collider weaponCollider;
    private Player_ControllerMove player;
    private Animation currentAnime;
    private engageArea[] area;

    private void Start()
    {
        weaponCollider = GetComponent<Collider>();
        player = FindObjectOfType<Player_ControllerMove>();
        area = FindObjectsOfType<engageArea>();

        weaponCollider.enabled = false;
    }

    private void Update()
    {
        if (player.getAnimator().GetCurrentAnimatorStateInfo(0).IsName("Throw_Weapon"))
            weaponCollider.enabled = true;
        else
            weaponCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            for(int i = 0; i < area.Length; i++)
            {
                if (area[i].getEnemyList().Contains(other.gameObject))
                {
                    area[i].getEnemyList().Remove(other.gameObject);
                    Destroy(other.gameObject);
                }
                else
                    Destroy(other.gameObject);
            }
        }

    }
}
