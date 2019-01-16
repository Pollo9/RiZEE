using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;	

public class HostGame : NetworkBehaviour
{

	[SerializeField] 
	private uint roomSize = 6;

	public GameObject objet;
	private string RoomName;
	private NetworkManager networkManager;

	public void Start()
	{
		networkManager = NetworkManager.singleton;
		if (networkManager.matchMaker == null)
		{
			networkManager.StartMatchMaker();
		}
	}
	public void SetRoomName(string _name)
	{
		RoomName = _name;
	}

	public void CreateRoom()
	{
		if (RoomName != "" && RoomName != null)
		{
			Debug.Log("Creation de la partie : " + RoomName + " avec " + roomSize + "places.");

			networkManager.matchMaker.CreateMatch(RoomName, roomSize, true, "", "", "", 0, 0,
				networkManager.OnMatchCreate);	
		}
		
	}

	public void createsolo()
	{
		SceneManager.LoadScene(3);
		gameObject.SetActive(false);
	}
	public void createsolo2()
	{
		Application.LoadLevel("foret");
	}

	public void createsolosolo()
	{
		Application.LoadLevel("all");
		gameObject.SetActive(false);
	}

 	
	



}
