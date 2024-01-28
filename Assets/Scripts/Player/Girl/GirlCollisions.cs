using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
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
            Debug.Log("COLLIDED WITH DARK");
            GameController.instance.Lose();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("light"))
        {
            GirlMovement.instance.canMove = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("light"))
        {
            GirlMovement.instance.canMove = false;
        }
    }
}
