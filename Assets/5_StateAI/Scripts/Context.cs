using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Context : MonoBehaviour //this class is responsible for maintaining the state subclass that defines the current state
{
    State currentstate;

    void Start()
    {
        currentstate = GetComponent<Roaming>();  //automatically first make the current state roaming/start moving in the scene
    }
    void Update()
    {
        currentstate.Action(this); //Setting the state action function owner to this context
    }
    public void Switch(State newState) //making a new function that takes a new state
    {
        currentstate = newState; //once the switch function is called it will change the currentstate to the new state
    }
}
