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
                if (playables.gameObject.GetComponent<IMovement>().isActiveAndEnabled == true)
                {
                    playables.gameObject.GetComponent<IMovement>().enabled = false;
                    Debug.Log("Desactived the active");
                }
                else if (playables.gameObject.GetComponent<IMovement>().isActiveAndEnabled == false)
                {
                    playables.gameObject.GetComponent<IMovement>().enabled = true;
                    Debug.Log("Actived the unnactive");
                }

            }
        }
    }
}
