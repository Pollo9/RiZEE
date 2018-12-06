using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotit : MonoBehaviour {
	
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
			GUI.Box(new Rect(Screen.width / 2, Screen.height / 3, 110, 25), "We got it !");	
		}
        		
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
