using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public static Timer instance;

    public Text timerCount;

    private TimeSpan timePlaying;

    //private bool timerOn;

    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timerCount.text = "Time: 00:00:00";
        //timerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        timePlaying = TimeSpan.FromSeconds(elapsedTime);
        string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss':'ff");
        timerCount.text = timePlayingStr;
    }
}
