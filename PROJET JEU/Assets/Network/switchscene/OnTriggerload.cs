using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerload : MonoBehaviour
{

	public GameObject guiobject;
	public int scene;
	private bool loaded = false;

	private void Start()
	{
		guiobject.SetActive(false);
	}

	private void OnTriggerStay(Collider other)
	{
		if (!loaded)
		{
			guiobject.SetActive(true);
			SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
			loaded = true;
		}
		
	}

	void OnTriggerExit()
	{
		guiobject.SetActive(false);
		
	}
}
