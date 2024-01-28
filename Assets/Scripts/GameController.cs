using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameController : MonoBehaviour
{
    public IPlayables[] characters;

    public CinemachineVirtualCamera primaryCamera;
    public CinemachineVirtualCamera secondaryCamera;
    private bool trocarCam = true;

    void TrocarCameraSecundaria(){

        CinemachineBrain cinemachineBrain = FindObjectOfType<CinemachineBrain>();
        cinemachineBrain.ActiveVirtualCamera.Priority = 1;
        secondaryCamera.Priority = 2;

    }

    void TrocarCameraPrincipal(){

        CinemachineBrain cinemachineBrain = FindObjectOfType<CinemachineBrain>();
        cinemachineBrain.ActiveVirtualCamera.Priority = 1;
        primaryCamera.Priority = 2;

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            foreach (IPlayables playables in characters)
            {
                //switch the IMovements
                if (playables.gameObject.GetComponent<IMovement>().isActiveAndEnabled == true)
                {
                    playables.gameObject.GetComponent<IMovement>().enabled = false;
                    Debug.Log("Desactived the active IMovement");
                }
                else if (playables.gameObject.GetComponent<IMovement>().isActiveAndEnabled == false)
                {
                    playables.gameObject.GetComponent<IMovement>().enabled = true;
                    Debug.Log("Active<d the unnactive IMovement");
                }

                if(trocarCam == true){
                    TrocarCameraSecundaria();
                    trocarCam = false;
                }else if(trocarCam == false){
                    TrocarCameraPrincipal();
                    trocarCam = true;
                } 
                //switch collisions
                if(playables.gameObject.GetComponent<ICollisions>().isActiveAndEnabled == true){
                    playables.gameObject.GetComponent<ICollisions>().enabled = false;
                    Debug.Log("Desactived the active ICollisions");
                }
                else if(playables.gameObject.GetComponent<ICollisions>().isActiveAndEnabled == false){
                    playables.gameObject.GetComponent<ICollisions>().enabled = true;
                    Debug.Log("Activated the unnactive ICollisions");
                }

            }
        }
    }
}
