using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayExplosion : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayDelayed(5.0f);  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
