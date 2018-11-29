﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]


public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera cam;

    private Vector3 velocity;
    private Vector3 rotation;
    private float cameraRotationX = 0f;
    private float currentCameraRotationX = 0f;

    [SerializeField]
    private float cameraRotationLimit = 85f;


    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    //Velocity pour le déplacement
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //Rotation pour le personnage
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //Rotation pour la camera
    public void RotateCamera(float _cameraRotationX)
    {
        cameraRotationX = _cameraRotationX;
    }



    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    private void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation()
    {
        //récuperation de la rotation + clamp de la rotation
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        currentCameraRotationX -= cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        //applique les changement à la camera après le clamp
        cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);

    }
}
