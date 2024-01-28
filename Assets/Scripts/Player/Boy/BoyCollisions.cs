using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoyCollisions : ICollisions
{
    [SerializeField]
    private float forceMagnitude;
    public float maxDistance;
    public CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {

    }

    void OnControllerColliderHit(ControllerColliderHit hitCon)
    {
        Vector3 direcao = new Vector3();
        Rigidbody rb = hitCon.collider.attachedRigidbody;

        RaycastHit[] hit;
        hit = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), 5);
        if (hit.Length > 0)
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxDistance, Color.green);
            if (hitCon.collider.CompareTag("box"))
            {
                //direcao = hit.normal * -100;
                Debug.Log("hit a box");
                Debug.Log(hit.Length);
                //hit.rigidbody.AddForce(direcao);
                if (hit.Length == 1)
                {
                    hit[0].transform.Translate(hit[0].normal * -2.5f);
                }

            }
        }

        int maxColliders = 10;

        LayerMask mask = LayerMask.GetMask("spotlights");
        Vector3 p1 = transform.position + controller.center;


        Collider[] hitColliders = new Collider[maxColliders];
        int numColliders = Physics.OverlapSphereNonAlloc(p1, controller.height/2, hitColliders, mask);
        for (int i = 0; i < numColliders; i++)
        {
            if (hitColliders[i].CompareTag("Spotlight"))
            {
                Debug.Log("joined the spotlight");
                BoyMovement.instance.allowedToLight = true;
                BoyMovement.instance.whichLight = hitColliders[i].gameObject.transform.GetComponentInChildren<LightSpotlight>();
            }

        }

    }

}

