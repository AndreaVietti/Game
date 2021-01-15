using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //variabili per il tempo
    public Text TimerText;
    private float StartTime;
    // Use this for initialization
    void Start()
    {
        StartTime = Time.time;//start del timer
        
    }

    // Update is called once per frame
    void Update()
    {
        //tempo trascorso - tempo di inizio
        float t = Time.time - StartTime;
        //divido per 60 ottenendo i minuti epoi faccio mudolo 60 per i secondi 
        string minuti = ((int)t / 60).ToString();
        //solo 2 numeri dopo la virgola
        string secondi = (t % 60).ToString("f2");
        //riscrivo minuti e secondi nel timer
        TimerText.text = "Timer: " + minuti + ":" + secondi;
    }
}
