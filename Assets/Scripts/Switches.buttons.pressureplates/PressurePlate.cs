using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will handle the PressurePlates.
/// Once the player (or a crate, stone block or another movable object)
/// steps on it, the connected door/bridge/moving_object will activate.
/// Once the object is pushed off or the player steps off the connected object
/// will either return to it's original point (this happens incase of doors)
/// and the objects will be de-activated.
/// For doors using the same system that is in the switches script.
/// </summary>

public class PressurePlate : MonoBehaviour {

    //gameObject
    [SerializeField]
    private GameObject _obj;

    //Bools
    public bool left;
    public bool right;
    public bool playerFound;

    //vector2
    public Vector2 moveValueX = new Vector2(0.1f, 0.0f);
    public Vector2 moveValueY = new Vector2(0.0f, 0.1f);
    private Vector2 _objToMove;

    //ints&floats
    /*-------------------
     * The float "moveObjByValue" is to move the object up/down/left/right with the given amount.
     * It is a public to make it adjustable for each object, incase a bridge is made, or something else
     * that needs a lower value then the standard 10f.
     --------------------*/
    public float moveObjByValue;
    public float timeForMove;
    //The weight of an object can be different, and a pressure plate needs a weight to be pressed.
    public float weightOfObj;

    void Start()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
