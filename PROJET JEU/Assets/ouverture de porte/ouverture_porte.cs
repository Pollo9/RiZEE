using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Boo.Lang;
using UnityEngine;

public class ouverture_porte : MonoBehaviour
{

	private Animator Anim_r;
	private Animator Anim_l;
	private bool inGUI;
	
	void Start ()
	{
		Anim_r = GameObject.Find("glass_door_left").GetComponent<Animator>();
		Anim_l = GameObject.Find("glass_door_right").GetComponent<Animator>();
	}
    
	void OnTriggerEnter(Collider other)
	{
		inGUI = true;
		Anim_r.SetBool("open", true);
		Anim_l.SetBool("open", true);
	}

	void OnTriggerExit(Collider other)
	{
		inGUI = false;
		
	}


	private void OnGUI()
	{
		if (inGUI)
		{ 
			GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 110, 25), "the door is open");	
		}
		
	}

	private void Update()
	{

		
	}
}
