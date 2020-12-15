using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    
    [SerializeField] private SceneTransitioner m_sceneTransitioner;
    [SerializeField] private GameObject m_gameOverPanel;
    [SerializeField] private GameObject m_gameOverScoreText;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayAgain()
    {
        m_sceneTransitioner.Transition(true);
        Time.timeScale = 1f;
        ScoreManager.Instance.ResetScore();
    }

    public void BackToMenu()
    {
        m_sceneTransitioner.Transition();
        Time.timeScale = 1f;
    }

    public void ShowGameOverScreen()
    {
        m_gameOverPanel.SetActive(true);

        if (ScoreManager.Instance.HighScoreWasUpdated)
        {
            m_gameOverScoreText.SetActive(true);
        }
        else
        {
            m_gameOverScoreText.SetActive(false);
        }
        
        Time.timeScale = 0f;
    }
}
