using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public IPlayables[] characters;
    void Update()
    {
        foreach(IPlayables playables in characters){
            // playables.SetActive()
        }
    }
}
