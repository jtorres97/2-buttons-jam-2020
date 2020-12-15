using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private SceneTransitioner m_sceneTransitioner;
    
    public void StartGame()
    {
        m_sceneTransitioner.Transition();
    }

    public void OpenHighscores()
    {
        // TODO: Show highscores here (highscore panel)
    }
}
