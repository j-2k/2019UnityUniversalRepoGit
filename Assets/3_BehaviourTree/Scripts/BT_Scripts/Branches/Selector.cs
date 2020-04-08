using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MainTree
{
    public override void Update_Action(AIBB ai)
    {
        for (int i = 0; i < childrenRef.Count; i++)
        {
            childrenRef[i].Update_Action(ai);
            if (childrenRef[i].curState == Result.Success || childrenRef[i].curState == Result.Running)
            {
                curState = childrenRef[i].curState;
                return;
            }
        }
        curState = Result.Fail;
        Debug.Log("Selector Node State : " + curState);
    }
}