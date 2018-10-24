using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptZombie : MonoBehaviour {
	

	private Vector3 ZombiePosition;
	private Animator _animator;
	private int _playerOnSightHash;
	private int _reachedPointHash;
    
	public Vector3 zombiePosition { get { return ZombiePosition; } }
	public int ReachedPointHash { get { return _reachedPointHash; } }
	private void Start()
	{
		ZombiePosition = transform.position;
		_animator = GetComponent(typeof(Animator)) as Animator;
		_playerOnSightHash = Animator.StringToHash("PlayerOnSight");
		_reachedPointHash = Animator.StringToHash("ReachedPoint");
	}
	private void OnTriggerEnter(Collider collider)
	{
		if(collider.CompareTag("Player"))
		{
			_animator.SetBool(_playerOnSightHash, true);
		}
	}
	private void OnTriggerExit(Collider collider)
	{
		if (collider.CompareTag("Player"))
		{
			_animator.SetBool(_playerOnSightHash, false);
		}
	}
}
