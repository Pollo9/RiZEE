using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(SetupP))]
public class Player : NetworkBehaviour {

	[SyncVar]
	private bool _isDead = false;
	public bool isDead
	{
		get { return _isDead; }
		protected set { _isDead = value; }
	}

    [SerializeField]
    private int maxHealth = 100;

    [SyncVar]
    private int currentHealth;

	public float GetHealthPct ()
	{ 
		return (float)currentHealth / maxHealth;
	}

	public float hblength;

	[SyncVar]
	public string username = "Loading...";

	[SerializeField]
	private Behaviour[] disableOnDeath;
	private bool[] wasEnabled;

	[SerializeField]
	private GameObject[] disableGameObjectsOnDeath;

	[SerializeField]
	private GameObject deathEffect;

	[SerializeField]
	private GameObject spawnEffect;

	private bool firstSetup = true;

	public void SetupPlayer ()
    {
		if (isLocalPlayer)
		{
			//Switch cameras
			GameManager.instance.SetSceneCameraActive(false);
                                          			
		}
    }

	private void Awake()
	{
		SetDefaults();
	}


	private void OnGUI()
	{
		GUI.Box(new Rect(10,10,hblength,30),currentHealth + "/" + maxHealth );
	}

	[ClientRpc]
    public void RpcTakeDamage (int _amount, string _sourceID)
    {
		if (isDead)
			return;

        currentHealth -= _amount;

        Debug.Log(transform.name + " now has " + currentHealth + " health.");

		if (currentHealth <= 0)
		{
			Die(_sourceID);
		}
    }

	private void Die(string _sourceID)
	{
		isDead = true;

		Player sourcePlayer = GameManager.GetPlayer(_sourceID);
		if (sourcePlayer != null)
		{
			GameManager.instance.onPlayerKilledCallback.Invoke(username, sourcePlayer.username);
		}


		//Disable components
		for (int i = 0; i < disableOnDeath.Length; i++)
		{
			disableOnDeath[i].enabled = false;
		}

		//Disable GameObjects
		for (int i = 0; i < disableGameObjectsOnDeath.Length; i++)
		{
			disableGameObjectsOnDeath[i].SetActive(false);
		}

		//Disable the collider
		Collider _col = GetComponent<Collider>();
		if (_col != null)
			_col.enabled = false;

		//Spawn a death effect
		GameObject _gfxIns = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(_gfxIns, 3f);

		//Switch cameras
		if (isLocalPlayer)
		{
			GameManager.instance.SetSceneCameraActive(true);
			
		}

		Debug.Log(transform.name + " is DEAD!");

	}

    public void SetDefaults ()
    {
		isDead = false;

        currentHealth = maxHealth;

		//Enable the components
		for (int i = 0; i < disableOnDeath.Length; i++)
		{
			disableOnDeath[i].enabled = wasEnabled[i];
		}

		//Enable the gameobjects
		for (int i = 0; i < disableGameObjectsOnDeath.Length; i++)
		{
			disableGameObjectsOnDeath[i].SetActive(true);
		}

		//Enable the collider
		Collider _col = GetComponent<Collider>();
		if (_col != null)
			_col.enabled = true;

		//Create spawn effect
		GameObject _gfxIns = (GameObject)Instantiate(spawnEffect, transform.position, Quaternion.identity);
		Destroy(_gfxIns, 3f);
	}

}
