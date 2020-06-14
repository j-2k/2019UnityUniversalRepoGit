using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recharging : State
{
    public Transform rechargePos;
    public float rechargeTimer = 0;
    public float reachingDistance;

    public override void Action(Context owner)
    {
        Debug.Log("Charging Bot");
        Vector3 direction2recharge = rechargePos.position - transform.position;
        if (direction2recharge.magnitude <= reachingDistance)
        {
            transform.position += Vector3.zero;
            rechargeTimer += Time.deltaTime;
            if (rechargeTimer > 10)
            {
                Roaming.batteryTimer = 30;
                rechargeTimer = 0;
                owner.Switch(GetComponent<Roaming>());
            }
        }
    }
    
}
