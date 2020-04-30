using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerMovementTest : MonoBehaviour
{
    public float playerSpeed;  // 5
    public float max_velocity; // 25
    
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 5;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += transform.forward * playerSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity += -transform.right * playerSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity += -transform.forward * playerSpeed;
        }
        if (Input.GetKey(KeyCode.D)) 
        { 
            rb.velocity += transform.right * playerSpeed;
        }
        if (rb.velocity.magnitude >= max_velocity)
        {
            rb.velocity = rb.velocity.normalized * max_velocity;
        }
    }

    private void OnDrawGizmosSelected()
    {
        //Debug
        Debug.DrawRay(transform.position + (transform.up * 3), rb.velocity, Color.black);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(rb.position + rb.velocity + (transform.up * 3), 1);
    }
}
