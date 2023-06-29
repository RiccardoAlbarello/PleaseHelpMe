using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject optionsCanvas;
    

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
