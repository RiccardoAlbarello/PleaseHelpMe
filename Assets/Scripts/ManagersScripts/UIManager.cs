using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject optionsCanvas;
    [SerializeField] GameObject pauseMenu;

    public static bool GameIsPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void PlayGame()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        optionsCanvas.SetActive(true);
    }

    public void QuitSettings()
    {
        optionsCanvas.SetActive(false);
    }
}
