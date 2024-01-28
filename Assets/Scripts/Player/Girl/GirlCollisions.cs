using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlCollisions : ICollisions
{
    void FixedUpdate()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("dark")){
            Debug.Log("Girl Collided With Dark");
        }
    }
}
