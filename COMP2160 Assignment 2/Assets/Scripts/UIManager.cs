using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject losePanel;
    public GameObject winPanel;

    private bool paused = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        AnalyticsResult analyticsResult = AnalyticsEvent.GameStart();
        Debug.Log("analyticsStart: " + analyticsResult);
        paused = false;
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        Time.timeScale = 1;
        Debug.Log (Timer.instance.timerCount.text);
    }

    void Update()
    {
        
    }

    public void GameOver()
    {
        AnalyticsResult analyticsResult = AnalyticsEvent.GameOver();
        Debug.Log (Timer.instance.timerCount.text);
        Debug.Log("analyticsGameOver: " + analyticsResult);
        paused = true;
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Victory()
    {
        AnalyticsResult analyticsResult = Analytics.CustomEvent("Victory" + Timer.instance.timerCount.text);
        Debug.Log (Timer.instance.timerCount.text);
        Debug.Log("analyticsVictory: " + analyticsResult);
        paused = true;
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
