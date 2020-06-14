using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCharge : State
{
    public Transform rechargePos;
    public float reachingDistance;

    public override void Action(Context owner)
    {
        Roaming.batteryTimer -= Time.deltaTime;
        Vector3 direction2recharge = rechargePos.position - transform.position;
        Debug.Log("Moving to Charger");
        Debug.Log(Roaming.batteryTimer);
        if (direction2recharge.magnitude > reachingDistance)
        {
            transform.position += transform.forward * 15 * Time.deltaTime;
            transform.LookAt(rechargePos.position);
        }

        if (direction2recharge.magnitude <= reachingDistance)
        {
            owner.Switch(GetComponent<Recharging>());
        }

        if (Roaming.batteryTimer <= 0)
        {
            owner.Switch(GetComponent<ShutDown>());
        }
    }
}
