using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
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
        float t = Time.time - StartTime;
        string min = ((int)t / 60).ToString();
        string sec = (t % 60).ToString("f2");
        TimerText.text = min + ":" + sec;
        StartMenu.player.timer = TimerText.text.ToString();
    }
}
