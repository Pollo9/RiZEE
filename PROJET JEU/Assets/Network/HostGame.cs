using UnityEngine;
using UnityEngine.Networking;	

public class HostGame : MonoBehaviour
{

	[SerializeField] 
	private uint roomSize = 6;

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
		Application.LoadLevel("all");
	}
	public void createsolo2()
	{
		Application.LoadLevel("foret");
	}

 	
	



}
