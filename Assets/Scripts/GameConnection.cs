using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using Photon.Pun;
using Photon.Realtime;

public class GameConnection : MonoBehaviourPunCallbacks
{

    public Text testLog;

    private void Awake(){

        testLog.text = "Connecting to Server...";
        Debug.Log("Connecting to Server..");

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster(){
        //runs commands on the original function
        base.OnConnectedToMaster();
        
        testLog.text = "Connected to Server!";
        Debug.Log("Connected to server!");

        if(PhotonNetwork.InLobby == false){
            Debug.Log("Joining lobby");

            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnJoinedLobby(){

        base.OnJoinedLobby();

        PhotonNetwork.JoinOrCreateRoom("test", null, null);

        testLog.text = "Joined Lobby!";
        Debug.Log("Joined Lobby!");


    }
}
