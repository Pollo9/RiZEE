using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Anymanager : MonoBehaviour
{


	public static Anymanager anymanager;
	private bool gamestart;

	private void Awake()
	{
		if (!gamestart)
		{
			anymanager = this;
			SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
			gamestart = true;
			
		}
	}

	public void Unloadscene(int scene)
	{
		StartCoroutine(Unload(scene));
	}

	IEnumerator Unload(int scene)
	{
		yield return null;
		SceneManager.UnloadScene(scene);
	}
}
