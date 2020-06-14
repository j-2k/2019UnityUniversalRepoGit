using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roaming : State
{
    public Transform[] paths;
    public float reachingDistance;
    public int currentPoint = 0;
    public static float batteryTimer = 30;

    public override void Action(Context owner)
    {
        batteryTimer -= Time.deltaTime;
        Debug.Log("Patrolling");
        Debug.Log(batteryTimer);

        // Direction Calculation
        Vector3 direction = paths[currentPoint].position - transform.position;

        //Movement Controlling
        transform.position += transform.forward * 15 * Time.deltaTime;

        //Rotation Information
        transform.LookAt(paths[currentPoint].position);

        //Destination Information
        if (direction.magnitude <= reachingDistance)
        {
            currentPoint++;
        }

        if (currentPoint >= paths.Length)
        {
            currentPoint = 0;
        }

        if (batteryTimer <= 10)
        {
            //batteryTimer = 30;
            owner.Switch(GetComponent<MoveToCharge>());
        }
    }
}
