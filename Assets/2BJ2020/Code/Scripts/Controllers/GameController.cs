using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    
    [SerializeField] private SceneTransitioner m_sceneTransitioner;
    [SerializeField] private GameObject m_gameOverPanel;
    [SerializeField] private GameObject m_gameOverScoreText;
    [SerializeField] private GameObject m_howToPlayPanel;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("FirstPlaythrough", 1) == 1)
        {
            // Set first time opening to false
            PlayerPrefs.SetInt("FirstPlaythrough", 0);

            // Do your stuff here
            m_howToPlayPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && m_howToPlayPanel.activeInHierarchy)
        {
            m_howToPlayPanel.SetActive(false);
            Time.timeScale = 1f;
        }
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

        m_gameOverScoreText.SetActive(ScoreManager.Instance.HighScoreWasUpdated);

        Time.timeScale = 0f;
    }
}
