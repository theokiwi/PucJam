using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{

    public GameObject player;
    public Transform spawnPoint;

    void Start()
    {
        Debug.Log(message: "Connecting....");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log(message: "Connected to Server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby(){

        base.OnJoinedLobby();

        PhotonNetwork.JoinOrCreateRoom(roomName: "test", roomOptions: null, typedLobby: null);
        Debug.Log("Joined Lobby!");     
        StartCoroutine(playerSpawn());
    
    }

    IEnumerator playerSpawn(){
        
        yield return new WaitForSeconds(5);
        PhotonNetwork.Instantiate("player", spawnPoint.position, Quaternion.identity, 0);    

    }


}
