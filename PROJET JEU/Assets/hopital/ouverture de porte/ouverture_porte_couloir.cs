using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ouverture_porte_couloir : MonoBehaviour
{
	private Animator Anim;
	private bool inGUI;
	
	void Start () {
		Anim = GameObject.Find("glass_door_c").GetComponent<Animator>();
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
			GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 110, 25), "the door is open");	
		}
		
	}
	
	void Update () {
		
	}
}
