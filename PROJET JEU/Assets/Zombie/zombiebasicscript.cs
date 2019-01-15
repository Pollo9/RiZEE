using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombiebasicscript : MonoBehaviour
{

    private Transform player;
    public List<GameObject> destinationpoints;
    public float speed;
    public float alertdistance;
    public float walkingdistance;
    public float attackingdistance;

    private Animator anim;
    private Vector3 direction;
    private NavMeshAgent agent;
    public AudioSource zombie_attack;
    public AudioSource zombie_breathing;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;

    }
   
    // Update is called once per frame
    void Update () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //alert
        if (Vector3.Distance(player.position, transform.position) < alertdistance &&
            Vector3.Distance(player.position, transform.position) > walkingdistance)
        {
            agent.enabled = false;
            anim.SetBool("isidle",false);
            anim.SetBool("isalert", true);
            anim.SetBool("iswalking",false);
            anim.SetBool("isattack",false);
            zombie_breathing.Play();
        }
        //attack & move
        else if (Vector3.Distance(player.position, transform.position) <= walkingdistance)
        {
            agent.enabled = true;
            agent.SetDestination(player.transform.position);
            anim.SetBool("isidle",false);
            anim.SetBool("isalert", false);
            anim.SetBool("iswalking",true);
            anim.SetBool("isattack",false);
            if (Vector3.Distance(player.position, transform.position) <= attackingdistance)
            {
                anim.SetBool("iswalking",false);
                anim.SetBool("isattack",true);
                zombie_attack.Play();
            }
        }
        //idle
        else if (anim.GetBool("isidle") == false && agent.enabled == false)
        {
            anim.SetBool("isidle",true);
            anim.SetBool("isalert", false);
            anim.SetBool("iswalking",false);
            anim.SetBool("isattack",false);
            zombie_breathing.Play();
        }
    }
}
