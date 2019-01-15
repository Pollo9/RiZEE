using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getobject : MonoBehaviour {

	public GameObject hacksaw;
    
    private void OnTriggerEnter()
    {
        
            hacksaw.SetActive(false);
        
    }

}
