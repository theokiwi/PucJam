using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseButtons : MonoBehaviour
{
     public void ReloadMenu()
    {
        UIManager.instance.currentCanvas.SetActive(false);
        SceneManager.LoadScene("Menu");
        UIManager.instance.currentCanvas = UIManager.instance.menuCanvas;
        UIManager.instance.currentCanvas.SetActive(true);
    }

     public void Quit()
    {
        Application.Quit();
    }
}
