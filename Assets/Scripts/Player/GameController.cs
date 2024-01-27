using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public IPlayables[] characters;
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
                    Debug.Log("Desactived the active");
                }
                else if (playables.gameObject.GetComponent<IMovement>().isActiveAndEnabled == false)
                {
                    playables.gameObject.GetComponent<IMovement>().enabled = true;
                    Debug.Log("Active<d the unnactive");
                }

                //switching the Cameras

                if(playables.cam.activeSelf){
                    playables.cam.SetActive(false);
                }
                else if(!playables.cam.activeSelf){
                    playables.cam.SetActive(true);
                }

            }
        }
    }
}
