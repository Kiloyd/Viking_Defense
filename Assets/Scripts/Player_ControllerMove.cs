﻿//This script is used to control the player with keyboard / controller mechanics. It is mostly meant 
//for playing the game on Standalone or Console

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_ControllerMove : MonoBehaviour 
{
	[SerializeField] float movementSpeed = 5.0f;	//The speed of the player
	[SerializeField] float turnSpeed = 1000f;		//The turn speed of the player

	Animator anim;	        //A reference to the player's animator component
	Rigidbody rigidBody;	//A reference to the player's rigidbody component
	Vector3 playerInput;	//A vector3 to store the player's x, y, and z controller input
    
    float playerAttack;
    
    private float timeBar;

    public Material wave;
    public float timeBarMaximum = 3f;
    public float recoverSpeed = 1f;
    public float timeSlowFactor = 0.5f;
    public bool timetrigger;

	void Start()
	{
		//Get references to the player's rigidbody and animator components
		rigidBody = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
        timeBar = 0f;
	}

	void FixedUpdate()
	{
		//If the GameManager exists AND it tells us that the game is over, leave
		if (GameManager.instance != null && GameManager.instance.IsGameOver ()) 
		{
			//Go back to our Idle animation by dropping the speed to 0
			anim.SetFloat ("Speed", 0f);
            anim.SetBool("Attack", false);
            return;
		}
		
		//Get the horizontal and vertical input (up/down/left/right arrows, WASD keys, controller analog stick, etc),
		//and store that input in our playerInput variable (there won't be any "y" input)
		playerInput.Set(Input.GetAxis("Horizontal"), 0f, Input.GetAxis ("Vertical"));

        playerAttack = Input.GetAxis("Attack");
        timetrigger = Input.GetMouseButtonDown(1);
        
        if (timeBar >= 0 && timeBar <= timeBarMaximum)
        {
            timeBar += recoverSpeed * Time.deltaTime;

            if (timetrigger)
            {
                Debug.Log("time slow");
                Time.timeScale = timeSlowFactor;
                StartCoroutine("timeSlowCount", timeBar);
            }
        }
        else if (timeBar > timeBarMaximum)
            timeBar = timeBarMaximum;
        
        anim.SetFloat("Attack", playerAttack);

        //Tell the animator the "speed" of our movement based on the magnitude 
        //of the vector (the numerical "value" of the vector)
        anim.SetFloat ("Speed", playerInput.sqrMagnitude);
        
		//If there is no input from the player, we're done here and can leave
		if (playerInput == Vector3.zero)
			return;

		//We take our input, multiply it by our speed, and then multiply Time.deltaTime. We then
		//add this amount to our current position to get the new desired position. NOTE: We "normalize"
		//our input so that the player won't move faster going diagonolly. NOTE: multiplying the value
		//with Time.deltaTime ensures that everyone has the same gameplay regardless of the speed of their
		//computers or the physics settings of the game
		Vector3 newPosition = transform.localPosition + playerInput.normalized * movementSpeed * Time.deltaTime;

		//Use the rigidbody to move to the new position. This is better than Transform.Translate since it means
		//the player will move with physics and force instead of just "teleporting" to the new spot
		rigidBody.MovePosition (newPosition);

		//Use the "Quaternion" class to determine the rotation we need to face the direction we want to go
		Quaternion newRotation = Quaternion.LookRotation (playerInput);  

		//If we need to turn and face a new direction, use the RotateTowards() method to turn quickly, but not
		//instantly (which looks better)
		if(rigidBody.rotation != newRotation) 
			rigidBody.rotation = Quaternion.RotateTowards(rigidBody.rotation, newRotation, turnSpeed * Time.deltaTime); 
	}
    
    IEnumerator timeSlowCount(float total)
    {
        yield return new WaitForSeconds(total * timeSlowFactor);

        Time.timeScale = 1;
        timeBar = 0;
        timetrigger = false;
        
        Debug.Log("time run");
    }

    public float getTimeBar()
    {
        return timeBar;
    }

    public float getAttack()
    {
        return playerAttack;
    }

    public Animator getAnimator()
    {
        return anim;
    }
}