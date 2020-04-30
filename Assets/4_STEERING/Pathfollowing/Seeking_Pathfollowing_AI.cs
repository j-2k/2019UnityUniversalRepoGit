using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeking_Pathfollowing_AI : MonoBehaviour
{
    public Transform[] paths;
    Rigidbody rb;
    public float reachingDistance;
    public int currentPoint = 0;
    Vector3 desiredVel; //direction
    Vector3 steering;
    Vector3 target;
    //public float speed; // important
    public float max_velocity;
    public float max_force;
    public float max_speed;
    public float rotSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //max_velocity = X; 40
        //max_force = X; 0.2
    }

    void FixedUpdate() //fixed update maybe
    {
        Debug.DrawRay(transform.position + new Vector3(0,1,0), transform.forward * 10f, Color.green);
        Debug.DrawRay(transform.position + new Vector3(0,-1,0), desiredVel.normalized * 10f, Color.blue);
        Debug.DrawRay(transform.position + new Vector3(0,0,0), steering.normalized * 15f, Color.white);
        // Seeking
        desiredVel = (paths[currentPoint].position - transform.position).normalized * max_velocity;
        steering = desiredVel - rb.velocity;
        if (steering.magnitude > max_force)
        {
            steering = steering.normalized * max_force;
        }
        if (rb.velocity.magnitude > max_speed)
        {
            rb.velocity = rb.velocity.normalized * max_speed;
        }
        Debug.DrawRay(transform.position + new Vector3(0, 10, 0), rb.velocity, Color.cyan);
        // Path Following
        target = paths[currentPoint].position - transform.position;
        Debug.DrawRay(transform.position + new Vector3(0, 5, 0), target, Color.red);
        if (target.magnitude <= reachingDistance)
        {
            currentPoint++;
        }
        if (currentPoint >= paths.Length)
        {
            currentPoint = 0;
        }
        //
        rb.velocity += steering;
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target), rotSpeed * Time.deltaTime);
        rb.rotation = Quaternion.LookRotation(rb.velocity);
    }
}
