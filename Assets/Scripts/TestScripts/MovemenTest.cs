using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovemenTest : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        
        float vertical = Input.GetAxis("Vertical");;
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;

        transform.Translate(dir * Time.deltaTime * speed);
    }
}
