using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class ouverture_porte : MonoBehaviour
{

	private Animator Anim;
	
	void Start ()
	{
		Anim = GameObject.Find("glass").GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider other)
	{
		Anim.SetBool("open",true);
	}

	void OnTriggerExit(Collider other)
	{
		Anim.SetBool("open",false);
	}

	private void Update()
	{
		
	}
}
