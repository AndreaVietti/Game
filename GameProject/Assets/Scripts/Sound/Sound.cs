using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField]
    AudioClip[] Audio;

    private int lung;
    // Use this for initialization
    void Start()
    {
        lung = Audio.Length;
        AudioSource c = this.GetComponent<AudioSource>();
        int r = Random.Range(0, lung);
        c.clip = Audio[r];
        c.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
