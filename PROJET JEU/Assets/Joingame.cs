using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using  UnityEngine.Networking.Match;

public class Joingame : MonoBehaviour
{
	List<GameObject> roomList = new List<GameObject>();
	[SerializeField] private Text status;
	[SerializeField] private GameObject roomListItemPrefab;
	[SerializeField] private Transform roomListParent;

	private NetworkManager _networkManager;

	private void Start()
	{
		_networkManager = NetworkManager.singleton;
		if (_networkManager.matchMaker == null)
		{
			_networkManager.StartMatchMaker();
		}
		//refresh list
		RefreshRoomList();
	}

	public void RefreshRoomList()
	{
		_networkManager.matchMaker.ListMatches(0, 20 ,"", true, 0, 0, OnmatchList);
		status.text = "Loading...";
	}


	public void OnmatchList(bool sucess, string extendedInfo, List<MatchInfoSnapshot> matchList)
	{
		status.text = "";
		
		if  (sucess || matchList == null)
		{
			status.text = "Couldn't get room list.";
			return;
		}

		ClearRoomlist();
		foreach (MatchInfoSnapshot match in matchList)
		{
			GameObject _roomListItemGO = Instantiate(roomListItemPrefab);
			_roomListItemGO.transform.SetParent(roomListParent);
			// have a component sit on the gameobjet
			//that will take of setting up the name/amout of users
			// as well as setting up a callback function that will join the game.
			roomList.Add(_roomListItemGO);
			
		}
	}

	void ClearRoomlist()
	{
		for (int i = 0; i < roomList.Count; i++)
		{
			Destroy(roomList[i]);
		}
		roomList.Clear();
	}
}
