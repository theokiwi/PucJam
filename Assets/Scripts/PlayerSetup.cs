using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public static PlayerSetup instance;
    // player selection essentials
    public int mySelectedCharacter;
    public GameObject[] allCharacters;  


    void OnEnable(){
        if(instance == null){
            instance = this;
        }
        else if (instance != this){
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }

    void Start(){
        if(PlayerPrefs.HasKey("MyCharToChoose")){
            mySelectedCharacter = PlayerPrefs.GetInt("MyCharToChoose");        }
        else{
            mySelectedCharacter = 0;
            PlayerPrefs.SetInt("MyCharToChoose", mySelectedCharacter);
        }
    }

    // public void isLocalPlayer(){

    //    p_movement.enabled = true;
    //    cam.SetActive(true);
    // }
}
