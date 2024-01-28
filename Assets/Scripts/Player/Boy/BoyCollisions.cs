using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyCollisions : ICollisions
{
    [SerializeField] 
    private float forceMagnitude;
    public float maxDistance;

    void FixedUpdate()
    {
        
    }

    void OnControllerColliderHit(ControllerColliderHit hitCon)
    {
        Rigidbody rb = hitCon.collider.attachedRigidbody;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit, maxDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxDistance, Color.green);
            if (hitCon.collider.CompareTag("box"))
            {
                Debug.Log("hit a box");
                Debug.Log(hit.normal);
                hit.rigidbody.AddForce(hit.normal * forceMagnitude);
            }
        }
  
    }
}
