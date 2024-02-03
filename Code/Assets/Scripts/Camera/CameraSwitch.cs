using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    public static CameraSwitch instance;
    List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
   public static CinemachineVirtualCamera ActiveCamera = null;

   void Awake(){
        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(instance.gameObject);
        }
   }

   public bool IsActiveCamera(CinemachineVirtualCamera camera){
        return camera == ActiveCamera;
   }

   public void SwitchCamera(CinemachineVirtualCamera camera){
        Debug.Log("called switch camera");
        camera.Priority = 10;
        ActiveCamera = camera;

        foreach (CinemachineVirtualCamera c in cameras){
            if(c != camera){
                c.Priority = 0;
            }
        }
   }

   public void Register(CinemachineVirtualCamera camera){
        cameras.Add(camera);
        Debug.Log("camera registered" + camera);
   }

   public void Unregister(CinemachineVirtualCamera camera){
        cameras.Remove(camera);
        Debug.Log("camera unregistered" + camera);

   }
}
