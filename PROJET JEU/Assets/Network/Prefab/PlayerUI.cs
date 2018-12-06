using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {


	[SerializeField]
	GameObject pauseMenu;

	private Player_Controller player;

	public void SetPlayer (Player_Controller _player)
	{
		player = _player;
	}

	void Start ()
	{
		PauseMenu.IsOn = false;
	}

	void Update ()
	{
	
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			TogglePauseMenu();
		}
		
	}

	public void TogglePauseMenu ()
	{
		pauseMenu.SetActive(!pauseMenu.activeSelf);
		PauseMenu.IsOn = pauseMenu.activeSelf;
    }


}
