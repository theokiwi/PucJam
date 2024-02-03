using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkShadowMove : MonoBehaviour
{
    public Waypoints nextWaypoint;

    public float speed;
    private void FixedUpdate()
    {
        Vector3 dir = nextWaypoint.transform.position - transform.position;
        if (dir.magnitude < 0.5f)
        {
            nextWaypoint = nextWaypoint.next;
        }
        dir = dir.normalized;
        Quaternion rot = Quaternion.LookRotation(dir);
        float t = Time.fixedDeltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, 2 * t);
        transform.Translate(Vector3.forward * speed * t);

    }
}
