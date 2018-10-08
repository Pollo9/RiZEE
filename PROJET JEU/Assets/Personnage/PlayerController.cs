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
	private int Jump = 3;
	private int Gravité = 15;
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

		if (Input.GetKey(KeyCode.LeftShift) & Input.GetKey(KeyCode.Z))
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

		// walk
		if (Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.D))
		{
			Anim.SetBool("Walk", true);
			Anim.SetBool("Run",false);
			Anim.SetBool("Walk L", false);
			Anim.SetBool("Walk R", false);
		}
		// walk left
		if (Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.D))
		{
			Anim.SetBool("Walk", true);
			Anim.SetBool("Run",false);
			Anim.SetBool("Walk L", true);
			Anim.SetBool("Walk R", false);
		}
		//walk right
		if (Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.D))
		{
			Anim.SetBool("Walk", true);
			Anim.SetBool("Run",false);
			Anim.SetBool("Walk L", false);
			Anim.SetBool("Walk R", true);
		}
		// run
		if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift)&& !Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.D))
		{
			Anim.SetBool("Walk", true);           
			Anim.SetBool("Run",true);
			Anim.SetBool("Walk L", false);
			Anim.SetBool("Walk R", false);
		}                                                     
		//run left                                            
		if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift)&& Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.D))
		{
			Anim.SetBool("Walk", true);           
			Anim.SetBool("Run",true);
			Anim.SetBool("Walk L", true);
			Anim.SetBool("Walk R", false);
		}
		// run right
		if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift)&& !Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.D))
		{
			Anim.SetBool("Walk", true);           
			Anim.SetBool("Run",true);
			Anim.SetBool("Walk L", false);
			Anim.SetBool("Walk R", true);
		}
		// stop walk
		if (Input.GetKeyUp(KeyCode.Z))
		{
			Anim.SetBool("Walk L",false);
			Anim.SetBool("Walk R", false);
			Anim.SetBool("Walk", false);
			Anim.SetBool("Run", false);
		}
		
		
		
		
		
		
	}
}
