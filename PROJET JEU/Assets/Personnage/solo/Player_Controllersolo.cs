using System;
using UnityEngine;

public class Player_Controllersolo : MonoBehaviour
{

    public float cameraRotationLimit = 50f;
    public float lookSensitivity = 4f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController Player;
    private Animator anim;
    private float currentCameraRotationX = 0f;

    [SerializeField]
    private Camera cam;
    // Use this for initialization
    void Start()
    {
        Player = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Player.transform.Rotate(0, Input.GetAxisRaw("Mouse X") * lookSensitivity, 0);
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * 200 * Time.deltaTime;
        moveDirection.y -= 500 * Time.deltaTime; //gravity
        Player.Move(moveDirection * Time.deltaTime);


        float _xRot = Input.GetAxisRaw("Mouse Y") * lookSensitivity;
        cam.transform.Rotate(-_xRot, 0, 0);

        currentCameraRotationX -= _xRot;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);

        //reload
        if (Input.GetKey(KeyCode.R))
        {
            anim.SetInteger("States", 30);
            anim.SetInteger("R_L", 0);
        }
        //Secret dance ;)
        if (Input.GetKey(KeyCode.P))
        {
            anim.SetInteger("States", 22);
            anim.SetInteger("R_L", 0);

        }

        /*if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.P) && Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D))
		{
			anim.SetInteger("States", 0);
			anim.SetInteger("R_L", 0);
		}
		*/

        // marche arrière
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("States", -1);
            anim.SetInteger("R_L", 0);
        }
        // marche avant
        if (Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("States", 1);
            anim.SetInteger("R_L", 0);
        }
        // marche avant droite
        if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("States", 1);
            anim.SetInteger("R_L", 1);
        }
        // marche avant gauche
        if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.Q))
        {
            anim.SetInteger("States", 1);
            anim.SetInteger("R_L", 2);
        }
        // marche arrière droite
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("States", -1);
            anim.SetInteger("R_L", 1);
        }
        // marche arrière gauche
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Q))
        {
            anim.SetInteger("States", -1);
            anim.SetInteger("R_L", 2);
        }
        // marche droite
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Z))
        {
            anim.SetInteger("States", 0);
            anim.SetInteger("R_L", 1);
        }
        // marche gauche
        if (Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.Z))
        {
            anim.SetInteger("States", 0);
            anim.SetInteger("R_L", 2);
        }

        // cas d' arrêt
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetInteger("States", 0);
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            anim.SetInteger("States", 0);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            anim.SetInteger("R_L", 0);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("R_L", 0);
        }

    }
}
