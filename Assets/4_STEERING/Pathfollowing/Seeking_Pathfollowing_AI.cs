using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeking_Pathfollowing_AI : MonoBehaviour
{                                               //https://gamedevelopment.tutsplus.com/tutorials/understanding-steering-behaviors-seek--gamedev-849
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
        // Seeking                                                                                      //The desired velocity is a force that pushes the character towards the target on the shortest path possbile
        desiredVel = (paths[currentPoint].position - transform.position).normalized * max_velocity;     // caculating the desired velocity goes like this DV = (target.pos - thisChar.pos) normalize the outcome then * by maximum velocity
        steering = desiredVel - rb.velocity;                                                            //steering force is the desired velocity subtracted by current velocity and it will pushe the character towards the target in what looks like a "curve"
        if (steering.magnitude > max_force)             //here we are restricting the steering force so that it dosent have too many forces acting upon this one object                                                                
        {
            steering = steering.normalized * max_force;                                                 
        }
        if (rb.velocity.magnitude > max_speed)          //here we are restricting the velocity of this object to it dosent go above the maximum speed
        {
            rb.velocity = rb.velocity.normalized * max_speed;
        }
        Debug.DrawRay(transform.position + new Vector3(0, 10, 0), rb.velocity, Color.cyan);
        // Path Following
        target = paths[currentPoint].position - transform.position;
        Debug.DrawRay(transform.position + new Vector3(0, 5, 0), target, Color.red);
        if (target.magnitude <= reachingDistance)   //change the currentpoint / waypoint
        {
            currentPoint++;
        }
        if (currentPoint >= paths.Length)           //reset currentpoint / waypoint when the limit is reached
        {
            currentPoint = 0;
        }
        //
        rb.velocity += steering;                    //finally add the steering force constantly to the object to get the curved look permanently when going from an angle
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target), rotSpeed * Time.deltaTime);
        rb.rotation = Quaternion.LookRotation(rb.velocity); //set the rotation to be the objects velocity direction
    }
}
