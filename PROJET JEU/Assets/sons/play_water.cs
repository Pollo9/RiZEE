using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_water : MonoBehaviour
{

	public AudioSource water;
		
	void OnTriggerEnter(Collider other)
	
	{
		water.Play();		
	}
}
