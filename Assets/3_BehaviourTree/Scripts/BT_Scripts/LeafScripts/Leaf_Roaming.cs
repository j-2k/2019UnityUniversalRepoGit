using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf_Roaming : MainTree
{
    public override void Update_Action(AIBB ai)
    {
        if (ai.batteryTimer >= 20)
        {
            ai.batteryTimer -= Time.deltaTime;
            Vector3 direction = ai.paths[ai.currentPoint].position - ai.transform.position;
            ai.transform.position += ai.transform.forward * ai.speed;
            ai.transform.LookAt(ai.paths[ai.currentPoint].position);

            if (direction.magnitude <= ai.reachingDistance)
            {
                ai.currentPoint++;
            }

            if (ai.currentPoint >= ai.paths.Length)
            {
                ai.currentPoint = 0;
            }
            /*
            curState = Result.Fail;     // Didnt add these because I dont think I need them
            or                          // 
            curState = Result.Success;  // since the branch node above this is just checking if it fails right?
            */
            curState = Result.Running;
            Debug.Log("Leaf Roaming Node State : " + curState);
            Debug.Log("<color=purple> ROAMING LEAF NODE </color>");
        }
        if (ai.batteryTimer <= 20)
        {
            Debug.Log("Timer is < 20 time to go change node & go backwards in the tree");
            curState = Result.Fail;
            Debug.Log("Leaf Roaming Node State : " + curState);
        }
    }
}
