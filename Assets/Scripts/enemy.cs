using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Animator anim;
    private bool engage;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    public void setTargetAndSpeed(Transform targetTransform, float speed)
    {
        target = targetTransform;
        movementSpeed = speed;
    }

    private void FixedUpdate()
    {
        MovingTowardTarget();
        anime();
    }

    void anime()
    {
        anim.SetFloat("Speed", movementSpeed);
        //anim.SetBool("Attack", attack);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "attackArea")
        {
            movementSpeed = 0;
            engage = true;
            anim.SetBool("engage", engage);
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "attackArea")
        {
            movementSpeed = 0;
            engage = true;
            anim.SetBool("engage", engage);
        }
    }

    void MovingTowardTarget()
    {
        if(target != null)
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, target.position, movementSpeed);
    }
}
