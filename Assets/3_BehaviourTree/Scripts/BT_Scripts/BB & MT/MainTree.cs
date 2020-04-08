using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainTree
{
    public enum Result
    {
        Fail = 0,
        Success = 1,
        Running = 2
    }
    public List<MainTree> childrenRef = new List<MainTree>();
    public Result curState;
    public abstract void Update_Action(AIBB ai);
}
