using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OnTriggerload : NetworkBehaviour
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
