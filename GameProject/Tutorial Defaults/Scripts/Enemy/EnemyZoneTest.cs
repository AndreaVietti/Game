using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

// Duplicate code from Laucher present, a super class can be introduced

public class EnemyZoneTest : MonoBehaviour
{
    public int fireRateSeconds = 5;

    // This has to be set from Inspector (or can be loaded at runtime from Resource path)
    public GameObject shot;
    public float shootSpeed = 20.0f;
    public Transform shotSpawn;
    public float rotationSpeedIntruder = 3f;

    private Transform _intruder;
    private float _cooldown = 0f;
    private float _cooldownTimer = 0f;
    private bool _canShoot = false;
    private uint _shotCounter = 0;

    // this can be handled better with Events
    private SimplePhysicsRotation _idleRotationBehaviour;
    private Rigidbody _rigidbody;

    void Awake()
    {
        _idleRotationBehaviour = GetComponentInParent<SimplePhysicsRotation>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _cooldown = 1f / fireRateSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        _cooldownTimer -= Time.deltaTime;

        _canShoot = false;

        if (_cooldownTimer <= 0f)
        {
            _canShoot = true;
        }

        if (_intruder)
        {
            if (shot && _canShoot)
            {
                _cooldownTimer = _cooldown;
                Shot shotInstance = Instantiate(shot, shotSpawn.position, Quaternion.LookRotation(shotSpawn.forward, shotSpawn.up)).GetComponent<Shot>();
                shotInstance.speed = shootSpeed;
                shotInstance.direction = shotSpawn.forward;
                shotInstance.gameObject.name = $"ENEMY_TURRET_SHOT_{_shotCounter:D3}";
                _shotCounter++;
            }
        }
    }

    void FixedUpdate()
    {
        if (_intruder)
        {
            Vector3 intruderDirection = (_intruder.transform.position - transform.position);
            intruderDirection.y = 0;
            intruderDirection.Normalize();
            Quaternion lerpToIntruder = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(intruderDirection, Vector3.up), rotationSpeedIntruder * Time.fixedDeltaTime);
            _rigidbody.rotation = lerpToIntruder;
        }
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnTriggerEnter(Collider other)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "Player")
        {
            _intruder = other.transform;
            if (_idleRotationBehaviour)
            {
                _idleRotationBehaviour.automatic = false;
            }
        }
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnTriggerExit(Collider other)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "Player" && GameObject.ReferenceEquals(_intruder.gameObject, other.gameObject))
        {
            _intruder = null;
            if (_idleRotationBehaviour)
            {
                _idleRotationBehaviour.SyncRotation();
                _idleRotationBehaviour.automatic = true;
            }
        }
    }
}