using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Unpause();
    }

    void Update()
    {
        
    }

    public void GameOver()
    {
        paused = true;
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Victory()
    {
        paused = true;
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        paused = false;
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        Time.timeScale = 1;

    }
}
