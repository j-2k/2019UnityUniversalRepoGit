using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBB : MonoBehaviour
{
    //=============//
    MainTree root;
    //=============//

    //==========WAYPOINT_VARIABLES==========//
    public Transform[] paths;
    public Transform rechargePos;

    public float speed; // important
    public float reachingDistance;
    public int currentPoint = 0;

    public float batteryTimer = 30;
    public float rechargeTimer = 0;
    //==========WAYPOINT_VARIABLES==========//


    void Start()
    {
        //Creating branch nodes into variables
        MainTree roamingUntillFailure = new Untill_Fail();

        MainTree chargingSequence = new Sequence();

        //Initializing the Root to begin the AI Behvaiours // Making the Tree
        root = new Selector();                                        // first top node is the selector
        root.childrenRef.Add(roamingUntillFailure);                 // 1st CHILD OF THE ROOT SELECTOR NODE, first is the until failure node
        roamingUntillFailure.childrenRef.Add(new Leaf_Roaming());   // now adding a child to the untill failure node which is the roaming code
        //root.childrenRef.Add(new Leaf_Roaming());

        root.childrenRef.Add(chargingSequence);                     // 2nd CHILD OF THE ROOT SELECTOR NODE,
        chargingSequence.childrenRef.Add(new Leaf_GoChargePos());
        chargingSequence.childrenRef.Add(new Leaf_Charging());
        chargingSequence.childrenRef.Add(new Leaf_CurrentNode());
    }

    void Update()
    {
        //=OWNER=//
        root.Update_Action(this);
        //=OWNER=//
    }
}
