using UnityEngine;
using UnityEngine.Networking;

[RequireComponent (typeof (WeaponManager))]
public class PlayerShoot : NetworkBehaviour
{

	private const string PLAYER_TAG = "Enemy";

	[SerializeField]
	private Camera cam;

	[SerializeField]
	private LayerMask mask;

	private PlayerWeapon currentWeapon;
	private WeaponManager weaponManager;

	void Start ()
	{
		if (cam == null)
		{
			Debug.LogError("PlayerShoot: No camera referenced!");
			this.enabled = false;
		}

		weaponManager = GetComponent<WeaponManager>();
	}

	void Update ()
	{
		currentWeapon = weaponManager.GetCurrentWeapon();

		if (PauseMenu.IsOn)
			return;

		if (currentWeapon.bullets < currentWeapon.maxBullets)
		{
			if (Input.GetButtonDown("Reload"))
			{
				weaponManager.Reload();
				return;
			}
		}

		if (currentWeapon.fireRate <= 0f)
		{
			if (Input.GetButtonDown("Fire1"))
			{
				Shoot();
			}
		} else
		{
			if (Input.GetButtonDown("Fire1"))
			{
				InvokeRepeating("Shoot", 0f, 1f/currentWeapon.fireRate);
			} else if (Input.GetButtonUp ("Fire1"))
			{
				CancelInvoke("Shoot");
			}
		}
	}





	[Client]
	void Shoot ()
	{
		if (!isLocalPlayer || weaponManager.isReloading)
		{
			return;
		}

		if (currentWeapon.bullets <= 0)
		{
			weaponManager.Reload();
			return;
		}

		currentWeapon.bullets--;

		Debug.Log("Remaining bullets: " + currentWeapon.bullets);


		RaycastHit _hit;
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, currentWeapon.range, mask) )
		{
			if (_hit.collider.tag == PLAYER_TAG ||_hit.collider.tag ==  "Player")
			{
				CmdPlayerShot(_hit.collider.name,currentWeapon.damage);
			}
		}
		if (currentWeapon.bullets <= 0)
		{
			weaponManager.Reload();
		}

	}

	[Command]
	void CmdPlayerShot (string _playerID,int damage)
	{
		Debug.Log(_playerID + " has been shot.");
		Player _player = GameManager.GetPlayer(_playerID);
		_player.RpcTakeDamage(damage,_playerID);
		Destroy(_player);

	}

}
