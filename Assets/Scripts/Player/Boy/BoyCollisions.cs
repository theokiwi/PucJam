using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyCollisions : ICollisions
{
    [SerializeField] 
    private float forceMagnitude;

    void FixedUpdate()
    {
        
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if(hit.collider.CompareTag("box")){
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rb.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
        }
    }
}
