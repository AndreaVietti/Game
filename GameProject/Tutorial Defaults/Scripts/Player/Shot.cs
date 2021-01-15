using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shot : MonoBehaviour
{
    public float speed = 40.0f;
    public Vector3 direction;
    public float lifeTime = 50.0f;
    public GameObject explosion;

    private Rigidbody _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // start with explosive velocity, also called impulse
        _rigidbody.AddForce(direction * 40.0f, ForceMode.VelocityChange);
    }

    void Update()
    {
        // handle life of the shot
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f)
        {
            // Destroy whole gameobject, if "this" is being used instead of gameObject -> then only this script (MonoBehaviour) will be destroyed
            StartCoroutine(DestroyRoutine(15.0f));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(DestroyRoutine(15.0f));
    }

    private IEnumerator DestroyRoutine(float time)
    {
        // handle how the shot is destroyed (briefly alive to show particles (from particle lesson))
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.detectCollisions = false;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        _rigidbody.isKinematic = true;
        if (explosion)
        {
            explosion.SetActive(true);
        }
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}