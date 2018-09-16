using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public float speed = 0.05f;
    public float deltaDistance = 0.5f;


    [SerializeField]
    private Collider fireball_collider;
    private Transform playerTransform;
    private float existTime = 7f;
    private float counting;
    private GameManager1 gm;

    private void OnEnable()
    {
        fireball_collider = GetComponent<Collider>();
        fireball_collider.isTrigger = true;
        playerTransform = FindObjectOfType<Player_ControllerMove>().transform;
        gm = FindObjectOfType<GameManager1>();
        counting = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("hit player");
            gm.playerDown = true;
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        this.transform.position += this.transform.forward * speed;

        counting += Time.deltaTime;
        if(counting >= existTime)
        {
            counting = 0;
            Destroy(this.gameObject);
        }
    }
}
