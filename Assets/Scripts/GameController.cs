using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameController : MonoBehaviour
{
    public IPlayables[] characters;

    public CinemachineVirtualCamera secondaryCamera;
    private bool trocarCam = true;

    void TrocarCameraSecundaria(){

        CinemachineBrain cinemachineBrain = FindObjectOfType<CinemachineBrain>();
        cinemachineBrain.ActiveVirtualCamera.Priority = 1;
        secondaryCamera.Priority = 2;

    }

    void TrocarCameraPrincipal(){

        CinemachineBrain cinemachineBrain = FindObjectOfType<CinemachineBrain>();
        cinemachineBrain.ActiveVirtualCamera.Priority = 2;
        secondaryCamera.Priority = 1;

    }

    public void OnEnable(){
        //CameraSwitch.instance.Register(boyCamera);
        //CameraSwitch.instance.Register(girlCamera);
        //CameraSwitch.instance.SwitchCamera(girlCamera);

    }

    public void OnDisable(){
        //CameraSwitch.instance.Unregister(boyCamera);
        //CameraSwitch.instance.Unregister(girlCamera);
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
        if(Input.GetKey("left ctrl")){
               if(trocarCam == true){
                    trocarCam = !trocarCam;                    
                    TrocarCameraPrincipal();
                    Debug.Log("Secundaria");
                    trocarCam = false;
                }else{
                    trocarCam = true;
                    TrocarCameraSecundaria();
                    Debug.Log("Principal");
                } 
        }
    }
}
