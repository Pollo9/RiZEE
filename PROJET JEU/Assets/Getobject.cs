using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getobject : MonoBehaviour {

	public GameObject hacksaw;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    private void OnTriggerEnter()
    {
        
            hacksaw.SetActive(false);
        obj1.SetActive(false);
        obj2.SetActive(false);
        obj3.SetActive(false);
        
    }

}
