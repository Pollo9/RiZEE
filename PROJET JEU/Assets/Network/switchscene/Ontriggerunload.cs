using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ontriggerunload : MonoBehaviour
{

	public int scene;
	private bool unloaded = false;

	public void Ontrigger()
	{
		if (!unloaded)
		{
			unloaded = true;
			Anymanager.anymanager.Unloadscene(scene);
			
		}

	}
}
	