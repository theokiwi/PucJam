using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        gameIsPaused = true;
    }

     public void ReloadMenu()
    {
        Time.timeScale = 1.0f;
        gameIsPaused = false;
        UIManager.instance.currentCanvas.SetActive(false);
        SceneManager.LoadScene("Menu");
        UIManager.instance.currentCanvas = UIManager.instance.menuCanvas;
        UIManager.instance.currentCanvas.SetActive(true);
    }
}
