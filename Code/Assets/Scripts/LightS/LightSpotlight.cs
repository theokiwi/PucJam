using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpotlight : MonoBehaviour
{
    public float speed;
    public float limit;
    public void ChangeSpotlight()
    {
        float angle = limit * Mathf.Sin(Time.time * speed);
        transform.rotation = Quaternion.Euler(0, 0, angle); 
    }
      
   
    
}