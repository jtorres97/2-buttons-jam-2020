using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private Text m_scoreText;
    [SerializeField] private Text m_highscoreText;

    public int Score { get; set; }
    public int HighScore { get; set; }
    public bool HighScoreWasUpdated { get; set; }

    private void Awake()
    {
        Instance = this;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            HighScore = PlayerPrefs.GetInt("HighScore");
            m_highscoreText.text = "HIGHSCORE: "+ HighScore;
        }
    }

    public void AddScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        UpdateHighScore();

        m_scoreText.text = "SCORE: " + Score;
    }

    public void RemoveScore(int scoreToRemove)
    {
        Score -= scoreToRemove;
    }

    public void UpdateHighScore()
    {
        if (Score > HighScore)
        {
            HighScore = Score;
            m_highscoreText.text = "HIGHSCORE: "+ HighScore;
            HighScoreWasUpdated = true;
            PlayerPrefs.SetInt("HighScore", HighScore);
        }
    }

    public void ResetScore()
    {
        Score = 0;
        m_scoreText.text = "SCORE: " + Score;
        m_highscoreText.text = "HIGHSCORE: "+ HighScore;
    }
}
