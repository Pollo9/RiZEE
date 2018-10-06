using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public int Speed = 5;
	public int RunSpeed = 10;

	private Vector3 DirectionDeplacement = Vector3.zero;
	private CharacterController Player;
	public int Sensi;
	public int Jump = 3;
	public int Gravité = 20;
	private Animator Anim;
	
	void Start ()
	{
		Player = GetComponent<CharacterController>();
		Anim = GetComponent<Animator>();

	}
	
	void Update ()
	{

		DirectionDeplacement.z = Input.GetAxisRaw("Vertical");
		DirectionDeplacement.x = Input.GetAxisRaw("Horizontal");
		DirectionDeplacement= transform.TransformDirection(DirectionDeplacement);
		
		//Deplacement

		if (Input.GetKey(KeyCode.LeftShift) & Input.GetKey(KeyCode.W))
		{
			Anim.SetBool("Run", true);
			Player.Move(DirectionDeplacement * Time.deltaTime * RunSpeed);
			
		}
		else
		{
			Anim.SetBool("Run", false);
			Player.Move(DirectionDeplacement * Time.deltaTime * Speed);

		}
		transform.Rotate(0,Input.GetAxisRaw("Mouse X")*Sensi,0);

		//Saut
		if (Input.GetKeyDown(KeyCode.Space) && Player.isGrounded)
		{
			DirectionDeplacement.y = Jump;
			Anim.SetTrigger("Jumping");
		}
		
		//Gravité
		if (!Player.isGrounded)
		{
			DirectionDeplacement.y -= Gravité*Time.deltaTime;
		}
		
		//Animations
		if ((Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.W)) & !Input.GetKey(KeyCode.LeftShift))
		{
			Anim.SetBool("Walk", true);
			Anim.SetBool("Run",false);
		}
		
		if ((Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.W)) & Input.GetKey(KeyCode.LeftShift))
		{
			Anim.SetBool("Walk", true);           
			Anim.SetBool("Run",true);
		}
		
		if (Input.GetKey(KeyCode.S) | Input.GetKeyUp(KeyCode.W))
		{
			Anim.SetBool("Walk", false);
			Anim.SetBool("Run", false);
		}
		
		
		
		
		
		
	}
}
