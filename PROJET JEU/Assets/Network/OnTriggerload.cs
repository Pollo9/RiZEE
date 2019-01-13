﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerload : MonoBehaviour
{

	public GameObject guiobject;
	public string leveltoLoad;

	private void Start()
	{
		guiobject.SetActive(false);
	}

	private void OnTriggerStay(Collider other)
	{
		
			guiobject.SetActive(true);
			if (guiobject.activeInHierarchy == true && Input.GetButtonDown("Use"))
			{
				Application.LoadLevel(leveltoLoad);
			}
		
	}

	void OnTriggerExit()
	{
		guiobject.SetActive(false);
	}
}
