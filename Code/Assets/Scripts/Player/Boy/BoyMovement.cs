using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyMovement : IMovement
{
    public static BoyMovement instance;
    public LightSpotlight[] lightSpot;
    public CharacterController controller;
    public float speed = 5f;

    public float turnTime = 0.1f;
    public float turnVelocity;

    public LightSpotlight whichLight;

    public bool allowedToLight;
    public bool alreadyPressed = false;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(instance.gameObject);
        }
        controller = GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;
        if(dir.magnitude >= 0.1f){
            
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            controller.Move(dir * speed * Time.deltaTime);
        }

        if (allowedToLight)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                whichLight.ChangeSpotlight();
                alreadyPressed = true;
            }
        }
        if(allowedToLight && alreadyPressed)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                allowedToLight = false;
                alreadyPressed = false;
            }
            
        }
        
    }
    

}
