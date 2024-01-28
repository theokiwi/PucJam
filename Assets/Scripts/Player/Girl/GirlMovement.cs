using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlMovement : IMovement
{
    public CharacterController controller;
    public float speed = 5f;

    public float jumpSpeed;
    public float ySpeed;

    public float turnTime = 0.1f;
    public float turnVelocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 dir = new Vector3(horizontal, 0, 0f);
        float magnitude = Mathf.Clamp01(dir.magnitude) * speed;
        dir.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded){
            ySpeed = 0f;

            if (Input.GetButton("Jump")){
            ySpeed = jumpSpeed;
        }
        }
        
        
        Vector3 velocity = dir * magnitude;
        velocity.y = ySpeed;

        controller.Move(velocity * Time.deltaTime);

        if(dir.magnitude >= 0.1f){

            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

        }
        
    }
}
