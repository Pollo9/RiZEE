using System;
using UnityEngine;
using UnityEngine.Networking;


public class Player_Controller : NetworkBehaviour
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

		//Secret dance ;)
		if (Input.GetKeyDown(KeyCode.P))
		{   
			anim.SetInteger("States", 22);
			anim.SetInteger("R_L",0);
			
		}
		
		/*if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.P) && Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D))
		{
			anim.SetInteger("States", 0);
			anim.SetInteger("R_L", 0);
		}
		*/
		
		// marche arrière
		if (Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
		{
			anim.SetInteger("States", -1);
			anim.SetInteger("R_L",0);
		}
		// marche avant
		if (Input.GetKeyDown(KeyCode.W)&& !Input.GetKeyDown(KeyCode.A)&& !Input.GetKeyDown(KeyCode.D))
		{
			anim.SetInteger("States", 1);
			anim.SetInteger("R_L",0);
		}
		// marche avant droite
		if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D))
		{
			anim.SetInteger("States", 1);
			anim.SetInteger("R_L",1);
		}
		// marche avant gauche
		if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A))
		{
			anim.SetInteger("States", 1);
			anim.SetInteger("R_L",2);
		}
		// marche droite
		if (Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.W))
		{
			anim.SetInteger("States", 0);
			anim.SetInteger("R_L", 1);
		}
		// marche gauche
		if (Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.W))
		{
			anim.SetInteger("States", 0);
			anim.SetInteger("R_L", 2);
		}
		
		// cas d' arrêt
		if(Input.GetKeyUp(KeyCode.S))
		{
			anim.SetInteger("States", 0);   
		}  
		
		if (Input.GetKeyUp(KeyCode.W))
		{
			anim.SetInteger("States", 0);  
		}
		if (Input.GetKeyUp(KeyCode.A))
		{ 
			anim.SetInteger("R_L",0);
		}

		if (Input.GetKeyUp(KeyCode.D))
		{ 
			anim.SetInteger("R_L",0);
		}
		
		        
	}
}
