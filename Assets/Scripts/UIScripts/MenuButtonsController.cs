using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonsController : MonoBehaviour
{
    public void OnClickPlay(string scene){
        UIManager.instance.CallPlay(scene);
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }

    public void Quit()
    {
        Application.Quit();
    }

}