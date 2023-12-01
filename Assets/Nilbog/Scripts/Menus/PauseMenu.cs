using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject creditsCanvas;
    private bool creditIsOpen = false;

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void CreditsCanvas()
    {
        if (creditIsOpen == false)
        {
            creditsCanvas.SetActive(true);
            creditIsOpen = true;
        }
        else
        {
            creditsCanvas.SetActive(false);
            creditIsOpen = false;
        }
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
