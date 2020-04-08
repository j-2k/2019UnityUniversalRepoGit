using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf_GoChargePos : MainTree
{
    public override void Update_Action(AIBB ai)
    {
        Vector3 direction2recharge = ai.rechargePos.position - ai.transform.position;

        if (direction2recharge.magnitude > ai.reachingDistance)
        {
            ai.batteryTimer -= Time.deltaTime;
            ai.transform.position += ai.transform.forward * ai.speed;
            ai.transform.LookAt(ai.rechargePos.position);
            curState = Result.Running;
        }

        if (direction2recharge.magnitude <= ai.reachingDistance)
        {
            curState = Result.Success;
        }
        Debug.Log("This msg should not show up if we are roaming");
    }
}
