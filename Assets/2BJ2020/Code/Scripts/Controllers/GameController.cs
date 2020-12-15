using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    
    [SerializeField] private SceneTransitioner m_sceneTransitioner;
    [SerializeField] private GameObject m_gameOverPanel;

    public int Score { get; set; }
    public int HighScore { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public void PlayAgain()
    {
        m_sceneTransitioner.Transition(true);
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        m_sceneTransitioner.Transition();
        Time.timeScale = 1f;
    }

    public void ShowGameOverScreen()
    {
        m_gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddScore(int scoreToAdd)
    {
        // TODO: Scoring system
    }

    public void NewHighScore(int newHighScore)
    {
        // TODO: Highscore systems
    }
}
