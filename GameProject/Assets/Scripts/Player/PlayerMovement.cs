using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
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

    [SerializeField]
    private GameObject life;

    public AudioClip fire;
    AudioSource audioSource;

    private Vector3 _translation = Vector3.zero;
    private Vector3 _rotation = Vector3.zero;

    public float MouseSensitivity = 5f;
    private bool _mouseMode = false;
    private bool isdeath = false;
    private bool fireAnim = false;

    public Animator animator;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            animator.SetBool("running", true);
            _translation *= SpeedUpMultiplier;
            _rotation *= SpeedUpMultiplier;
        }
        else
        {
            animator.SetBool("running", false);
        }

        if (Input.GetButton("Jump") && _isGrounded == true)
        {
            //adds force to player on the y axis by using the flaot set for the variable jumpForce. Causes the player to jump
            _body.velocity = new Vector3(0f, JumpHeight, 0f);
            //says the player is no longer on the ground
            _isGrounded = false;
            animator.SetBool("jump", true);
        }


        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }

        if (life.transform.localScale.x <= 0)
        {
            Speed = 0f;
            JumpHeight = 0f;
            SpeedUpMultiplier = 0f;
            SpeedRotate = 0f;
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void FixedUpdate()
    {
        _body.MovePosition(_body.position + _translation * Speed * Time.fixedDeltaTime);
        _body.MoveRotation(_body.rotation * Quaternion.Euler(_rotation * SpeedRotate * Time.fixedDeltaTime));
    }

    //checks if player has hit a collider
    void OnCollisionEnter(Collision other)
    {
        //checks if collider is tagged "ground"
        if (other.gameObject.CompareTag("ground"))
        {
            //if the collider is tagged "ground", sets onGround boolean to true
            _isGrounded = true;
        }
        animator.SetBool("jump", false);

        if (other.gameObject.tag.Equals("ground"))
        {
            _isGrounded = true;
        }

        if(other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("MadeKit"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("DangerKit"))
        {
            Destroy(other.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Hostage"))
        {
            SceneManager.LoadScene("WinMap");
        }
    }
    private IEnumerator WaitFor(float s)
    {
        yield return new WaitForSeconds(s);
    }

}