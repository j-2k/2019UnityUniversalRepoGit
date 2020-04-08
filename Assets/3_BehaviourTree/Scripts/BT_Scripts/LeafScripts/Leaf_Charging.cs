using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf_Charging : MainTree
{
    public override void Update_Action(AIBB ai)
    {
        ai.transform.position += Vector3.zero;
        ai.rechargeTimer += Time.deltaTime;
        curState = Result.Running;

        if (ai.rechargeTimer >= 10)
        {
            ai.rechargeTimer = 0;
            ai.batteryTimer = 30;
            curState = Result.Success;
        }
    }
}
