using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private CharacterController character_Controller;
	private Vector3 move_Direction;
	public float speed = 5f;
	public float gravity = 20f;
	public float jumpForce = 10f;
	private float verticalVelocity;
	private Transform camTransform;
	private float coolDown = 0;
	private Vector3 lastPlayerPosition;
	private int dieCount = 0;
	public bool isSafe = true;

	private void Awake() 
	{
		character_Controller = GetComponent<CharacterController>();
		camTransform = Camera.main.GetComponent<Transform>();
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

        if (Input.GetButtonDown("Fire1"))
        {
            PlayerDie();
		}

		if (Time.time >= coolDown)
		{
			if(isSafe)
            lastPlayerPosition = StorePlayerPosition();

			coolDown = Time.time + 2f;
		}

        if (character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
			PlayerJump();
        }

		

        move_Direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

		if (move_Direction.sqrMagnitude > 0)
		{
			if (character_Controller.velocity.sqrMagnitude > 0)
			{
                transform.forward = new Vector3(character_Controller.velocity.x, 0f, character_Controller.velocity.z);
			}
			
			
		}

        move_Direction = camTransform.TransformDirection(move_Direction);
        move_Direction *= speed * Time.deltaTime;
        ApplyGravity();
        character_Controller.Move(move_Direction);
       
       
	}

	// void MoveThePlayer()
	// {
       
		
	// }

	void ApplyGravity()
	{
    	verticalVelocity -= gravity * Time.deltaTime;
		move_Direction.y = verticalVelocity * Time.deltaTime;
	}

    void PlayerJump()
    {
        verticalVelocity = jumpForce;
    }

	public Vector3 StorePlayerPosition()
	{
		return transform.position;
	}

	public void PlayerDie()
	{
		dieCount++;
		transform.position = lastPlayerPosition;
		Debug.Log("Died");
	}
	
}
