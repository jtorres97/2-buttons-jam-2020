using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private SceneTransitioner m_sceneTransitioner;
    [SerializeField] private GameObject m_highScoresPanel;
    
    public void StartGame()
    {
        m_sceneTransitioner.Transition();
    }

    public void OpenHighscores()
    {
        // TODO: Show highscores here (highscore panel)
        m_highScoresPanel.SetActive(true);
    }

    public void CloseHighScores()
    {
        m_highScoresPanel.SetActive(false);
    }
}
