using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HelpMe : MonoBehaviour
{
    private float timeRemaining = 5;
    public float timer = 5;

    public AudioClip helpMe;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (timeRemaining <= 0)
        {
            audioSource.PlayOneShot(helpMe, 1.0f);
            timeRemaining = timer;
        }
    }
}