using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlCollisions : ICollisions
{
    
    private void FixedUpdate()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
    }

 

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered collision enter");
        if (other.gameObject.CompareTag("dark"))
        {
            GameController.instance.Lose();
        }
        if (other.gameObject.CompareTag("enemy"))
        {
            GameController.instance.Lose();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("light"))
        {
            GirlMovement.instance.canMove = true;
        }
        if (other.gameObject.CompareTag("win"))
        {
            Debug.Log("win");
            GameController.instance.Win();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("light"))
        {
            GirlMovement.instance.canMove = false;
        }
    }
}
