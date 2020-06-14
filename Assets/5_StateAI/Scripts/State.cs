using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract void Action(Context owner); //We make a abstract function that dosnt need a body it then
                                                //takes in the contexts owner which is set in the context class
    //this function uses polymorphism & keeps changing  the states that will happen within the AI's system
}

//Abstract Classes cannot be instantiated/ Are Designed to be inherited by subclasses that use/override its functions.
