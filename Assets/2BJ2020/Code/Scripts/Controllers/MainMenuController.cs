using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("2BJ2020_Game");
    }

    public void OpenHighscores()
    {
        SceneManager.LoadScene("2BJ2020_Highscores");
    }
}
