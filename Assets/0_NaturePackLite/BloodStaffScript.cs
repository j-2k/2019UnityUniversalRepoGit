using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;
using UnityEngine;

public class BloodStaffScript : MonoBehaviour
{
    public float timer;
    public Transform transform1;
    public Transform transform2;
    public float speed;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer < 3)
        {
            //transform.position += Vector3.up * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, transform2.position, Time.deltaTime * speed);
            transform.Rotate(0, 0, 2);
        }
        if (timer > 3)
        {
            //transform.position -= Vector3.up * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, transform1.position, Time.deltaTime * speed);
            transform.Rotate(0, 0, -2);
            if (timer >= 6)
            {
                timer = 0;
            }
        }
    }
}
