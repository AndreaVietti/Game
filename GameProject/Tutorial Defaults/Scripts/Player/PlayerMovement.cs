using System;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 10f;
    public float JumpHeight = 2f;
    public float SpeedUpMultiplier = 5f;
    public float SpeedRotate = 20f;

    private Rigidbody _body;

    public float GroundDistance = 0.2f;
    public LayerMask Ground;
    public Transform _groundChecker;
    private bool _isGrounded = true;

    private Vector3 _translation = Vector3.zero;
    private Vector3 _rotation = Vector3.zero;

    public float MouseSensitivity = 5f;
    private bool _mouseMode = false;

    public Animator animator;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // check if ground below character is present
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (animator)
        {
            animator.SetInteger("vertical", (int)Math.Round(moveZ));
            animator.SetInteger("horizontal", (int)Math.Round(moveX));
        }

        bool speedUp = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _mouseMode = !_mouseMode;
        }

        float rotationY = 0;

        if (_mouseMode)
        {
            // Let Unity take control of the cursor, so it will not click outside game window
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            rotationY += Input.GetAxis("Mouse X") * MouseSensitivity;
        }
        else
        {
            // Release cursor control
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (Input.GetKey(KeyCode.Q))
            {
                rotationY -= 1;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                rotationY += 1;
            }
        }

        // adapt input to where the character local rotation, otherwise wasd will move in world space
        _translation = Vector3.zero;
        _translation += transform.forward * moveZ;
        _translation += transform.right * moveX;

        _rotation = Vector3.up * rotationY;

        if (speedUp)
        {
            _translation *= SpeedUpMultiplier;
            _rotation *= SpeedUpMultiplier;
        }


        // Uncomment below to change player direction based on where it is going
        // if (_inputs != Vector3.zero)
        //     transform.forward = _inputs;

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }

    void FixedUpdate()
    {
        _body.MovePosition(_body.position + _translation * Speed * Time.fixedDeltaTime);
        _body.MoveRotation(_body.rotation * Quaternion.Euler(_rotation * SpeedRotate * Time.fixedDeltaTime));
    }
}