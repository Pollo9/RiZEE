using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class WeaponManager : NetworkBehaviour {

	[SerializeField]
	private string weaponLayerName = "Weapon";

	[SerializeField]
	private Transform weaponHolder;

	[SerializeField]
	private PlayerWeapon primaryWeapon;

	private PlayerWeapon currentWeapon;


	public bool isReloading = false;

	void Start ()
	{
		EquipWeapon(primaryWeapon);
	}

	public PlayerWeapon GetCurrentWeapon ()
	{
		return currentWeapon;
	}



	void EquipWeapon (PlayerWeapon _weapon)
	{
		currentWeapon = _weapon;

		GameObject _weaponIns = (GameObject)Instantiate(_weapon.graphics, weaponHolder.position, weaponHolder.rotation);
		_weaponIns.transform.SetParent(weaponHolder);

	}

	public void Reload ()
	{
		if (isReloading)
			return;

		StartCoroutine(Reload_Coroutine());
	}

	private IEnumerator Reload_Coroutine ()
	{
		Debug.Log("Reloading...");

		isReloading = true;

		yield return new WaitForSeconds(currentWeapon.reloadTime);

		currentWeapon.bullets = currentWeapon.maxBullets;

		isReloading = false;
	}




}
