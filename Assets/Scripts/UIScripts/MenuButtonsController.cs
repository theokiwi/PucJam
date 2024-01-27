using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonsController : MonoBehaviour
{
    public void OnClickPlay(string scene){
        UIManager.instance.CallPlay(scene);
    }
}