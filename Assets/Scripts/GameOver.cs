using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public bool isGameOver = false;
    public static GameOver instance;
    public TMP_Text scoreText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOverNow()
    {
        if (!isGameOver)
        {
            gameOverPanel.SetActive(true);
            scoreText.text = "SCORE: " + Scoring.totalScore;
            isGameOver = true;
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level1");
    }
}
