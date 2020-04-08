using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    public Transform[] paths;
    public Transform rechargePos;

    public float speed; // important
    public float reachingDistance;
    public int currentPoint = 0;

    public float batteryTimer;
    public float rechargeTimer = 0;

    void Start()
    {
        batteryTimer = 30;
    }

    void Update()
    {
        if (batteryTimer >= 20)
        {
            batteryTimer -= Time.deltaTime;
            Debug.Log(batteryTimer);
            Vector3 direction = paths[currentPoint].position - transform.position;
            transform.position += transform.forward * speed;
            transform.LookAt(paths[currentPoint].position);

            if (direction.magnitude <= reachingDistance)
            {
                currentPoint++;
            }

            if (currentPoint >= paths.Length)
            {
                currentPoint = 0;
            }
        }

        if (batteryTimer <= 20)
        {
            Debug.Log(batteryTimer);
            Vector3 direction2recharge = rechargePos.position - transform.position;

            if (direction2recharge.magnitude > reachingDistance)
            {
                batteryTimer -= Time.deltaTime;
                transform.position += transform.forward * speed;
                transform.LookAt(rechargePos.position);
            }

            if (direction2recharge.magnitude <= reachingDistance)
            {
                transform.position += Vector3.zero;
                rechargeTimer += Time.deltaTime;
                if (rechargeTimer >= 10)
                {
                    rechargeTimer = 0;
                    batteryTimer = 30;
                }
            }
        }
    }
}