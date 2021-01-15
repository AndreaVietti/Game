using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// make sure that rigidbody will be present
// Beware that required script will be added only on newly attached script!
[RequireComponent(typeof(Rigidbody))]
public class SimplePhysicsRotation : MonoBehaviour
{
    public float speedMultiplier = 1.0f;
    public bool automatic = true;

    private Rigidbody _rigidbody;
    private Vector3 _rotation;

    // Awake is called before Start
    void Awake()
    {
        // Initialize stuff here
        _rigidbody = GetComponent<Rigidbody>();
        _rotation = transform.localEulerAngles;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get data from other components/gameobjects here
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // transform is present in every monobehaviour and it refers to the Transform component

        // gameobject refers to object that holds this script

        // transform.Rotate(Vector3.up, Time.deltaTime * speedMultiplier, Space.Self);
        if (automatic)
        {
            _rotation += Vector3.up * Time.fixedDeltaTime * speedMultiplier;
            _rigidbody.MoveRotation(Quaternion.Euler(_rotation));
        }
    }

    public void SyncRotation()
    {
        _rotation = _rigidbody.rotation.eulerAngles;
    }
}