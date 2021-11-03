using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public static Timer instance;

    public Text timerCount;

    public Text finalTime1;

    public Text finalTime2;

    private TimeSpan timePlaying;

    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timerCount.text = "Time: 00:00:00";
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        timePlaying = TimeSpan.FromSeconds(elapsedTime);
        string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss':'ff");
        timerCount.text = timePlayingStr;
        finalTime1.text = timePlayingStr;
        finalTime2.text = timePlayingStr;
    }
}
