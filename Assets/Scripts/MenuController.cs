using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void OnClickCharPick(int whichChar){
        if(PlayerSetup.instance != null){
            PlayerSetup.instance.mySelectedCharacter = whichChar;
            PlayerPrefs.SetInt("MyCharToChoose", whichChar);
        }
    }
}
