using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerload : MonoBehaviour
{

	public int scene;
	private bool loaded = false;
	public void OntriggerEnter()
	{
		print("ahahahah");
		//if (!loaded)
		{
			//SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
			//loaded = true;
		}
		SceneManager.LoadScene(scene);
	}
}
