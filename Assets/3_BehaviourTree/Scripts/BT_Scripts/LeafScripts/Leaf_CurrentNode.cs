using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf_CurrentNode : MainTree
{
    public override void Update_Action(AIBB ai)
    {
        Vector3 direction = ai.paths[ai.currentPoint].position - ai.transform.position;
        ai.transform.position += ai.transform.forward * ai.speed;
        ai.transform.LookAt(ai.paths[ai.currentPoint].position);
        curState = Result.Running;

        if (direction.magnitude <= ai.reachingDistance)
        {
            curState = Result.Success;
        }
    }
}
