using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Untill_Fail : MainTree
{
    public override void Update_Action(AIBB ai)
    {
        for (int i = 0; i < childrenRef.Count; i++)             //Runs all the childrens of the node
        {
            Debug.Log("UNTILL FAILURE NODE (IN FORLOOP)");
            childrenRef[i].Update_Action(ai);                   //
            if (childrenRef[i].curState == Result.Fail)
            {
                Debug.Log("CHILD RETURNED FAIL & SHOULD GO OUT OF THIS NODE");
                curState = childrenRef[i].curState;
                Debug.Log(" INSIDE // Untill_Fail Node State : " + curState);
                return;
            }
        }
        curState = Result.Running;
        Debug.Log("Untill_Fail Node State : " + curState);
    }
}