using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.U2D;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
	public float speed = 0.2f;
	public float gravity = 20f;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController Cc;
	private Animator anim;
	// Use this for initialization
	void Start ()
	{
		Cc = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Cc.isGrounded)
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
		}
		
		moveDirection.y -= gravity * Time.deltaTime;
		Cc.Move(moveDirection * Time.deltaTime);



		if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.W))
		{
			anim.SetInteger("States", 0);
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			anim.SetInteger("States", -1);
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			anim.SetInteger("States", 1);
		}
		if (Input.GetKeyUp(KeyCode.W))
		{
			anim.SetInteger("States", 0);   
		}  
		if(Input.GetKeyUp(KeyCode.S))
		{
			anim.SetInteger("States", 0);   
		}  
	}
}
