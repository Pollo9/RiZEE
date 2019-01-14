using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using UnityEngine.AI;

[RequireComponent(typeof(SetupP))]
public class Player : NetworkBehaviour
{


	[SyncVar]
	private bool _isDead = false;
	public bool isDead
	{
		get { return _isDead; }
		protected set { _isDead = value; }
	}
	private NavMeshAgent agent;
	private Animator anim;
	
    [SerializeField]
    private int maxHealth = 100;
	
	[SyncVar]
	public int currentHealth;

	public float GetHealthPct ()
	{ 
		return (float)currentHealth / maxHealth;
	}

	[SyncVar]
	public string username = "Loading...";

	public int kills;
	public int deaths;

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


	

	[ClientRpc]
    public void RpcTakeDamage (int _amount, string _sourceID)
    {
		if (isDead)
			return;

        currentHealth -= _amount;

        Debug.Log(transform.name + " now has " + currentHealth + " health.");

		if (currentHealth <= 0)
		{
			anim = GetComponent<Animator>();
			agent = GetComponent<NavMeshAgent>();
			agent.enabled = false;
			anim.SetBool("isidle",false);
			anim.SetBool("isalert", false);
			anim.SetBool("iswalking",false);
			anim.SetBool("isattack",false);
			anim.SetBool("isdead",true);
			float startTime = Time.time;
			while(startTime + 5f > Time.time)
			{
				Die();
			}
		}
    }

	private void Die()
	{

		Destroy(this.gameObject);

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
