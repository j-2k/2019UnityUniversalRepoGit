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
        wanderRadiusPosition = transform.position + (rb.velocity.normalized * wanderCircleDistance);

        targetVec = wanderRadiusPosition + (transform.forward * wanderCircleRadius);

        timer += Time.deltaTime;
        if (timer >= 0.5)
        {
            displacementDir = targetVec - wanderRadiusPosition;
            displacementDir = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up) * displacementDir;
            timer = 0;
        }
        Debug.DrawRay(wanderRadiusPosition, displacementDir, Color.white);

        pointOnCircle = wanderRadiusPosition + (displacementDir.normalized * wanderCircleRadius);

        desiredVel = (pointOnCircle - transform.position).normalized * max_velocity;
        steering = desiredVel - rb.velocity;

        if (steering.magnitude > max_force)
        {
            steering = steering.normalized * max_force;
        }

        if (rb.velocity.magnitude > max_speed)
        {
            rb.velocity = rb.velocity.normalized * max_speed;
        }

        rb.velocity += steering;
        Debug.DrawRay(transform.position, rb.velocity, Color.blue);
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
