using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;

    public void resume()
    {
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        GameIsPaused = false;
    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        GameIsPaused = true;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit()
    {
        SceneManager.LoadScene("LevelMenu");
    }
}
