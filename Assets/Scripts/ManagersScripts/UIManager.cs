using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject optionsCanvas;
    [SerializeField] GameObject principalMenu;
    public SaveExample sE;
    

    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        sE.SaveBool();
        sE.SaveGame();
        Debug.Log("SaveBool");
        Application.Quit();
    }

    public void Settings()
    {
        optionsCanvas.SetActive(true);
        principalMenu.SetActive(false);
    }

    public void QuitSettings()
    {
        optionsCanvas.SetActive(false);
        principalMenu.SetActive(true);
    }
}
