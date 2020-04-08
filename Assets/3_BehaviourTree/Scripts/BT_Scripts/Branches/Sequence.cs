using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MainTree
{
    public override void Update_Action(AIBB ai)
    {
        for (int i = 0; i < childrenRef.Count; i++)
        {
            childrenRef[i].Update_Action(ai);
            if (childrenRef[i].curState == Result.Running || childrenRef[i].curState == Result.Fail)
            {
                curState = childrenRef[i].curState;
                return;
            }
        }
        curState = Result.Success;
        Debug.Log("This msg should not show up if we are roaming");
    }
}
