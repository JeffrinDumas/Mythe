using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is the input manager, it manages the input given in:
/// Edit>Project_Settings>Input
/// </summary>

public class Input_Manager : MonoBehaviour {

    [SerializeField]
    private float axisThreshhold = 0.2f;

    public bool Left()
    {
        return Input.GetAxis("Horizontal") < -axisThreshhold;
    }
    public bool Right()
    {
        return Input.GetAxis("Horizontal") > axisThreshhold;
    }
    public bool Up()
    {
        return Input.GetAxis("Vertical") > axisThreshhold;
    }
    public bool Down()
    {
        return Input.GetAxis("Vertical") < -axisThreshhold;
    }
    public bool Jump()
    {
        return Input.GetButton("Jump");
    }
    public bool Action()
    {
        return Input.GetButton("Fire1");
    }

}
