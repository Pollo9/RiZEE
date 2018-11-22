using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Boo.Lang;
using UnityEngine;

public class ouverture_porte : MonoBehaviour
{

	private Animator Anim;
	private bool inGUI;
	
	
	

	void Start ()
	{
		Anim = GameObject.Find("glass").GetComponent<Animator>();
	}
    
	
	
	private void Update()
	{

		
	}
	
	void OnTriggerEnter(Collider other)
	{
		inGUI = true;
		Anim.SetBool("open", true);	
	}

	void OnTriggerExit(Collider other)
	{
		inGUI = false;
		
	}


	private void OnGUI()
	{
		if (inGUI)
		{ 
			GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Open door");	
		}
		
	}

	
}
