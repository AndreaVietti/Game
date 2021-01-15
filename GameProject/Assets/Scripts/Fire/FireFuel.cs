﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireFuel : MonoBehaviour
{
    private float timeRemaining = 20;
    private float radius = 5.0f;

    public GameObject myPrefab;

    [SerializeField]
    private GameObject life;

    private float valOfLifeRemoved;
    private float percentageOfLifeRemoved = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        valOfLifeRemoved = life.transform.localScale.x * percentageOfLifeRemoved / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (timeRemaining <= 0)
        {
            Destroy(myPrefab);
        }

    }


    public void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider near in colliders)
        {

            Rigidbody rb = near.GetComponent<Rigidbody>();
            if (rb != null)
            {
                if (rb.tag.Equals("Player"))
                {
                    if (life.transform.localScale.x > 0)
                    {
                        life.transform.localScale = new Vector3(life.transform.localScale.x - valOfLifeRemoved, life.transform.localScale.y, life.transform.localScale.z);
                        Destroy(myPrefab);
                    }
                }
            }
        }
    }
}
