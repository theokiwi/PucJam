using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviourPunCallbacks, IInRoomCallbacks
{

    public RoomManager instance;

    private PhotonView pv;

    public GameObject player;

    public GameObject joinButton;
    public GameObject cancelButton;

    public int currentScene;
    public int mpScene;

    public Vector3 puzzlerSpawn;
    public Vector3 platformerSpawn;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else if (instance != this){
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        pv = GetComponent<PhotonView>();

    }

    void Start()
    {
        Debug.Log(message: "Connecting....");
        PhotonNetwork.ConnectUsingSettings();
    }

    //Joins Room

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        joinButton.SetActive(true);
        Debug.Log(message: "Connected to Server");  
    }

    public override void OnJoinedLobby(){

        base.OnJoinedLobby();
        Debug.Log("Joined Lobby!");     

        PhotonNetwork.JoinOrCreateRoom(roomName: "test", roomOptions: null, typedLobby: null);
     
    }

    public override void OnJoinedRoom(){
        
        base.OnJoinedRoom();

        Debug.Log("Joined Room!");

        StartGame();
        
    }

    public override void OnEnable(){
        base.OnEnable();

        Debug.Log("OnEnableCalled");

        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public override void OnDisable(){
        base.OnDisable();

        Debug.Log("OnDisableCalled");

        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode){
        currentScene = scene.buildIndex;
        if(currentScene == mpScene){
            CreatePlayer();
        }
    }

    
    //Game Starter Func

    public void StartGame(){
        Debug.Log("Start Game Called");
        // if(PhotonNetwork.IsMasterClient){
        //     return;
        // }

        PhotonNetwork.LoadLevel(mpScene);
    }
    
    //button func

    public void OnJoinClicked(){
        joinButton.SetActive(false);
        cancelButton.SetActive(true);    

        PhotonNetwork.JoinLobby();
                                                 
    }

    public void OnCancelClicked(){
        cancelButton.SetActive(false);
        joinButton.SetActive(true);

        PhotonNetwork.LeaveRoom();
    }

    //Object Instantiation

    void CreatePlayer(){

        Debug.Log("Player Create Called");

        Vector3 spawnPos = new Vector3(0f,51f,0f);

        PhotonNetwork.Instantiate("player", spawnPos, Quaternion.identity, 0);
    }
    


}
