using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfollowingAI : MonoBehaviour
{
    public Transform[] paths;
    Rigidbody rb;

    public float speed; // important
    public float reachingDistance;
    public int currentPoint = 0;

    public float max_velocity;
    public float max_force;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 direction = paths[currentPoint].position - transform.position;
        /*
        transform.position += transform.forward * speed;
        transform.LookAt(paths[currentPoint].position);
        */
        Vector3 desiredvelocity = (paths[currentPoint].position - transform.position).normalized * max_velocity;
        Vector3 steering = (desiredvelocity - rb.velocity);
        if (steering.magnitude < max_force)
        {
            steering = steering.normalized * max_force;
        }
        if (direction.magnitude <= reachingDistance)
        {
            currentPoint++;
        }

        if (currentPoint >= paths.Length)
        {
            currentPoint = 0;
        }

        steering = steering / rb.mass;
        rb.velocity += transform.forward * max_force;
        rb.velocity += steering;
    }
}
