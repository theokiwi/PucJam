using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject menuCanvas;

    public GameObject pauseMenu;

    public static bool gameIsPaused = false;

    public GameObject deathCanvas;

    public GameObject winCanvas;

    public GameObject laprasCanvas;

    public GameObject theoCanvas;

    public GameObject optionsCanvas;

    public GameObject currentCanvas;


    

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else if (instance != this){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
    
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
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
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    void Pause()
    {
        currentCanvas.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        gameIsPaused = true;
        currentCanvas = pauseMenu;
    }

    public void OnClickButtonMenu()
    {
        Time.timeScale = 1.0f;
        gameIsPaused = false;
        SceneManager.LoadScene("Menu");
    }

    public void CallPlay(string scene){
        currentCanvas.SetActive(false);
        LoadScene(scene);
    }

    IEnumerator passTest()
    {
        Debug.Log("called waiting");
        yield return new WaitForSeconds(5f);
    }
    public void CallDeath()
    {
        currentCanvas = deathCanvas;
        deathCanvas.SetActive(true);
    }

    public void CallWin()
    {
        currentCanvas = winCanvas;
        winCanvas.SetActive(true);
    }

    public void LoadScene(string scene){
        SceneManager.LoadScene(scene);
    }

}
