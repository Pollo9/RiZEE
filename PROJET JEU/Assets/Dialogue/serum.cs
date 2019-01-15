﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serum : MonoBehaviour {
	
	private bool inGUI;
	private bool sortie = true;

	void OnTriggerEnter(Collider other)
	{
		inGUI = true;
	}
	void OnTriggerExit(Collider other)
	{
		inGUI = false;
		sortie = false;
	}
    	
	private void OnGUI()
	{
		if (inGUI && sortie)
		{ 
			GUI.Box(new Rect(Screen.width / 2, Screen.height / 3, 300, 25), "Got this, let's clean this place and go back home !");	
		}
        		
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
