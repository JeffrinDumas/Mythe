using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will handle the switches, calls for their interracion
/// By placing doors in the empty gameobject slot you link it.
/// By checking one of the bools (up, down) the door will slide up or down.
/// </summary>

public class Switches : MonoBehaviour {

    //gameObject
    [SerializeField]
    private GameObject _obj;

    //Bools
    public bool up;
    public bool down;
    public bool left;
    public bool right;
    public bool playerFound;
    public bool buttonPressed;

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
    public float moveObjByValue = 100.5f;
    public float timeForMove = 10f;

    private void Start()
    {
        _objToMove = new Vector2(_obj.transform.position.x, _obj.transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision found");
        if (other.gameObject.tag == "Player")
        {
            playerFound = true;
            Debug.Log("Player found: " + playerFound);
        }
        else
        {
            playerFound = false;
        }
    }

    void Update()
    {
        _obj.transform.position = _objToMove;

        if (playerFound == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                buttonPressed = true;
                Debug.Log("Fire1 Pressed");
            }
        }
        if (buttonPressed == true)
        {
            if (up == true)
            {
                Debug.Log(up);
                Debug.Log(down);
                Debug.Log(left);
                Debug.Log(right);
                ObjUp();
            }
            if (down == true)
            {
                Debug.Log(up);
                Debug.Log(down);
                Debug.Log(left);
                Debug.Log(right);
                ObjDown();
            }
        }
        /*if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("test input");
            if (up == true)
            {
                Debug.Log(up);
                Debug.Log(down);
                Debug.Log(left);
                Debug.Log(right);
                ObjUp();
            }
            if (down == true)
            {
                Debug.Log(up);
                Debug.Log(down);
                Debug.Log(left);
                Debug.Log(right);
                ObjDown();
            }
            if (left == true)
            {
                Debug.Log(up);
                Debug.Log(down);
                Debug.Log(left);
                Debug.Log(right);
                ObjLeft();
            }
            if (right == true)
            {
                Debug.Log(up);
                Debug.Log(down);
                Debug.Log(left);
                Debug.Log(right);
                ObjRight();
            }
        }*/
    }

    void ObjUp()
    {
        _obj.transform.position = new Vector2((_obj.transform.position.x), moveObjByValue);
        Debug.Log("Up");
    }

    /*void ObjDown()
    {
        _obj.transform.position = new Vector2((_obj.transform.position.x), -moveObjByValue);
        Debug.Log("Down");
    }*/

    void ObjDown()
    {
        _objToMove.y = Mathf.Lerp(_objToMove.y, -moveObjByValue, timeForMove);
        Debug.Log("Down");
    }

    void ObjLeft()
    {
        _obj.transform.position = new Vector2(-moveObjByValue, (_obj.transform.position.y));
        Debug.Log("Left");
    }
    
    void ObjRight()
    {
        _obj.transform.position = new Vector2(moveObjByValue, (_obj.transform.position.y));
        Debug.Log("Right");
    }
}
