using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class WanderingAI : MonoBehaviour
{
    public float speed = 1.0f;
    public float obstacleRange = 3.0f;
    public string obstacleTag = "Obstacle";

    private Vector3 _position;
    private Vector3 _rotation;
    private Rigidbody _rigidbody;
    float distance = 0f;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _position = transform.localPosition;
    }

    void Update()
    {
        // transform.Translate(0, 0, speed * Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.transform.tag == obstacleTag && hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                _rigidbody.MoveRotation(Quaternion.Euler(new Vector3(0, angle, 0)) * transform.localRotation);
                distance = 0;
            }
        }

        if (distance >= 10)
        {
            float angle = Random.Range(-110, 110);
            _rigidbody.MoveRotation(Quaternion.Euler(new Vector3(0, angle, 0)) * transform.localRotation);
            distance = 0;
        }
        _position += Time.deltaTime * speed * transform.forward;
        _rigidbody.MovePosition(_position);
        distance += Time.deltaTime * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}