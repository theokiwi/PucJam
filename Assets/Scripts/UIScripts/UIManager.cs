using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Canvas menuCanvas;
    void Awake(){
        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(instance.gameObject);
    }

    public void CallPlay(string scene){
        menuCanvas.enabled = false;
        LoadScene(scene);
    }

    public void LoadScene(string scene){
        SceneManager.LoadScene(scene);
    }
}
