﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class Zombie_Target : NetworkBehaviour
{
	private NavMeshAgent agent;
    private Transform myTransform;
    public Transform targetTransform;
    private LayerMask raycastLayer;
    private float radius = 100;
	private Animator anim;
	public float attackingdistance;
	public float walkingdistance;
     
     	// Use this for initialization
     	void Start ()
	     {
		    anim = GetComponent<Animator>();
     		agent = GetComponent<NavMeshAgent>();
     		myTransform = transform;
     		raycastLayer = 1<<LayerMask.NameToLayer("Player");
		     agent.enabled = false;
     
     		if(isServer)
     		{
     			StartCoroutine(DoCheck());
     		}
     	}
     
     	// Update is called once per frame
     	void FixedUpdate () 
     	{
     		SearchForTarget();
     		MoveToTarget();
     	}
     
     	void SearchForTarget()
     	{
     		if(!isServer)
     		{
     			return;
     		}
     
     		if(targetTransform == null)
     		{
     			Collider[] hitColliders = Physics.OverlapSphere(myTransform.position, radius, raycastLayer);
     
     			if(hitColliders.Length>0)
     			{
     				int randomint = Random.Range(0, hitColliders.Length);
     				targetTransform = hitColliders[randomint].transform;
				    agent.enabled = false;
				    anim.SetBool("isidle",false);
				    anim.SetBool("isalert", true);
				    anim.SetBool("iswalking",false);
				    anim.SetBool("isattack",false);
     			}
     		}
		     else
		     {
			     if (Vector3.Distance(targetTransform.position, transform.position) <= walkingdistance)
			     {
				     agent.enabled = true;
				     agent.SetDestination(targetTransform.transform.position);
				     anim.SetBool("isidle",false);
				     anim.SetBool("isalert", false);
				     anim.SetBool("iswalking",true);
				     anim.SetBool("isattack",false);
				     if (Vector3.Distance(targetTransform.position, transform.position) <= attackingdistance)
				     {
					     anim.SetBool("iswalking",false);
					     anim.SetBool("isattack",true);
				     }
			     }
			     else
			     {
				     agent.enabled = false;
				     anim.SetBool("isidle",true);
				     anim.SetBool("isalert", false);
				     anim.SetBool("iswalking",false);
				     anim.SetBool("isattack",false);
			     }
		     }
     
     		if(targetTransform != null && targetTransform.GetComponent<BoxCollider>().enabled == false)
     		{
     			targetTransform = null;
     		}
     	}
     
     	void MoveToTarget()
     	{
     		if(targetTransform != null && isServer)
     		{
			     SetNavDestination(targetTransform);
     		}
     	}
     
     	void SetNavDestination(Transform dest)
     	{
     		agent.SetDestination(dest.position);
     	}
     
     	IEnumerator DoCheck()
     	{
     		for(;;)
     		{
     			SearchForTarget();
     			MoveToTarget();
     			yield return new WaitForSeconds(0.2f);
     		}
     	}
 }
