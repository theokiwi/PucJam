using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AvatarSetup : MonoBehaviour
{
    private PhotonView pv;
    private GameObject myCharacter;
    public int charValue;

    void Start()
    {
        pv = GetComponent<PhotonView>();
        if(pv.IsMine){
        pv.RPC("RPC_AddCharacter", RpcTarget.AllBuffered, PlayerSetup.instance.mySelectedCharacter);
        }
    }

    [PunRPC]
    void RPC_AddCharacter(int whichCharacter){
        charValue = whichCharacter;
        myCharacter = Instantiate(PlayerSetup.instance.allCharacters[whichCharacter], transform.position, transform.rotation, transform);
    }
    
}
