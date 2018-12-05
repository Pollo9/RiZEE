using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Zombie_Target : NetworkBehaviour 
 {
     private Transform target; //the enemy's target
     private float moveSpeed = 3f; //move speed
     private float rotationSpeed = 3f; //speed of turning
     private float range = 20f;
     private float range2 = 20f;
     private float stop = 10;
     private Transform myTransform; //current transform data of this enemy
     private LayerMask raycastLayer;
 
     //Shooting
     public GameObject shot;
     public Transform shotSpawn;
     private int randomCount;
 
     void Awake()
     {
         myTransform = transform; //cache transform data for easy access/preformance
     }
   
     void Start()
     {
         raycastLayer = 1 << LayerMask.NameToLayer ("Player"); //target the player
     }
   
     void FixedUpdate () 
     {
         moveToTarget ();
     }
 
     void Update ()
     {
         randomCount = Random.Range (1, 100);
         if (!isServer) 
             return;
 
         var distance2 = Vector3.Distance(myTransform.position, target.position);
         if (distance2 <= range) 
         {
             CmdDoFire ();            
         }    
     }
 
     void moveToTarget ()
     {
         if (!isServer)
             return;
 
         if (target != null && isServer) 
         {
             Collider[] distance = Physics.OverlapSphere (myTransform.position, range, raycastLayer);
             
             if (distance.Length > 0) 
             {
                 int randomint = Random.Range (0, distance.Length);
                 target = distance[randomint].transform;
             }
             
             var distance1 = Vector3.Distance(myTransform.position, target.position);
             
             if (distance1 <= range2 && distance1 >= range) 
             {
                 myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
                  Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
             } 
             else if (distance1 <= range && distance1 > stop) 
             { 
                 //move towards the player
                 myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
                 Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
                 myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
             } 
             else if (distance1 <= stop) 
             {
                 myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
                  Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
             }
         }
     }
 
     [Command]
     void CmdDoFire ()
     {
         if (randomCount < 2) 
         {
             GameObject instance = (GameObject)Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
             GetComponent<AudioSource> ().Play ();
             NetworkServer.Spawn (instance);
         }
     }
 }
