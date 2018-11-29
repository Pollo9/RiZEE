using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {

    [SerializeField]
    public float speed = 5;
    [SerializeField]
    public float lookSensitivity = 5;


    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        //On va calculer la vélocité du mouvement du joueur en un Vecteur 3D
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _yMov = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _moveVertical = transform.forward * _yMov;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        motor.Move(_velocity);

        //On va calculer la rotation du joueur en un Vecteur 3D
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0, _yRot, 0) * lookSensitivity;

        motor.Rotate(_rotation);

        //On va calculer la rotation du joueur en un Vecteur 3D
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _camerarotation = new Vector3(_xRot, 0, 0) * lookSensitivity;

        motor.RotateCamera(_camerarotation);


    }
}
