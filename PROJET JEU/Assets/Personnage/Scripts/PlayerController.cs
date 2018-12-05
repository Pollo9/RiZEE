using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {

    [SerializeField]
    public float speed = 5;
    [SerializeField]
    public float lookSensitivityX = 5;
    [SerializeField]
    public float lookSensitivityY = 5;

    private CharacterController Cc;

    private Animator anim;


    private PlayerMotor motor;

    private void Start()
    {
        Cc = GetComponent<CharacterController>();
        motor = GetComponent<PlayerMotor>();
        anim = GetComponent<Animator>();
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

        Vector3 _rotation = new Vector3(0, _yRot, 0) * lookSensitivityX;

       // motor.Rotate(_rotation);

        //On va calculer la rotation du joueur en un Vecteur 3D
        float _xRot = Input.GetAxisRaw("Mouse Y");
        
       float _camerarotationX = _xRot * lookSensitivityY;

       // motor.RotateCamera(_camerarotationX);

        if (Input.GetKey(KeyCode.P))
        {
            anim.SetInteger("States", 22);
            anim.SetInteger("R_L", 0);

        }

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
