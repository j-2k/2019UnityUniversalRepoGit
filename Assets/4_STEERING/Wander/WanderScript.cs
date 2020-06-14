using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class WanderScript : MonoBehaviour
{
    //WANDERING
    public int wanderCircleRadius = 3;
    public int wanderCircleDistance = 5;
    public float timer;
    Vector3 wanderRadiusPosition;
    Vector3 targetVec;
    Vector3 displacementDir;
    Vector3 pointOnCircle;

    //SEEKING
    Vector3 desiredVel;
    Vector3 steering;
    Vector3 wanderForce;
    public float max_velocity;
    public float max_force;
    public float max_speed;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Wandering
        wanderRadiusPosition = transform.position + (rb.velocity.normalized * wanderCircleDistance);    //first set the position of the wander circle to be always placed in front of the object

        targetVec = wanderRadiusPosition + (transform.forward * wanderCircleRadius);                    // have a target velocity that will always point from the center of the circle to the edge of the circle

        timer += Time.deltaTime;
        if (timer >= 0.5)                                                                               //each 0.5 seconds this if statement will run and randomize a random angle range between 0 and 360 on the y axis (turning on the y axis) 
        {
            displacementDir = targetVec - wanderRadiusPosition;                                         //the displacementdirection is taking the vectors mag and setting it to be in the middle of the circle then 
            displacementDir = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up) * displacementDir; //going outwards to then be changed by the randomized angle of 0-360 i was talking about previously
            timer = 0;
        }
        Debug.DrawRay(wanderRadiusPosition, displacementDir, Color.white);

        pointOnCircle = wanderRadiusPosition + (displacementDir.normalized * wanderCircleRadius);       //this places a vector 3 point on the edge of the circle by taking the center pos then adding the vector that got changed FROM the angle randomizer
                                                                                                        //then wherever the vector points it will place a point on the edge of that vector/head of the vector
        //Seeking
        desiredVel = (pointOnCircle - transform.position).normalized * max_velocity;                    //then we steer towards the point on the circle
        steering = desiredVel - rb.velocity;

        if (steering.magnitude > max_force)
        {
            steering = steering.normalized * max_force;
        }

        if (rb.velocity.magnitude > max_speed)
        {
            rb.velocity = rb.velocity.normalized * max_speed;
        }

        rb.velocity += steering;                                                                        // this technically should take the velocity vector into account and "add" the magnitudes together when the wander vector changes 
        Debug.DrawRay(transform.position, rb.velocity, Color.blue);                                     //but it would bug out a lot and this seems much more efficent
        rb.rotation = Quaternion.LookRotation(rb.velocity);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(wanderRadiusPosition, wanderCircleRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(targetVec, 1);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(pointOnCircle, 0.5f);
    }
}
