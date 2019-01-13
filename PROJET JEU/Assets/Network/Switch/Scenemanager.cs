using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour {

	public static Scenemanager Instance { set; get; }

	private void Awake()
	{
		Instance = this;
		Load("Menu");
		Load("Lobby");
		Load("Player");
		Load("map hopital");
		Load("Sous-sol");
		Load("foret");
		
	}

	private void Load(string scenename)
	{
		if (!SceneManager.GetSceneByName(scenename).isLoaded)

		{
			SceneManager.LoadScene(scenename, LoadSceneMode.Additive);
		}
	}

	public void Unload(string scenename)
	{
		if (SceneManager.GetSceneByName(scenename).isLoaded)
		{
			SceneManager.UnloadScene(scenename);
		}
	}
}
