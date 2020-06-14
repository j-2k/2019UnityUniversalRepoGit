using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDown : State
{
    public override void Action(Context owner)
    {
        transform.position += Vector3.zero;
        transform.Rotate(3f, 3f, 3f);
        Debug.Log("No more battery left... Shutting Down");
    }
}
