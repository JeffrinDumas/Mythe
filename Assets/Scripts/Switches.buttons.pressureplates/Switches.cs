using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will handle the switches and pressureplates, calls for their interacion
/// By placing doors in the empty gameobject slot you link it.
/// Place the object you want to move in the place of _obj in the inspector.
/// _moveToValue is the value the object will move to.
/// _movePerStep is the step amount it will take for the object to move to the _moveToValue location.
/// </summary>

public class Switches : MonoBehaviour {

    //gameObject
    [Header("GameObject")]
    [SerializeField]
    [Tooltip("This is the gameobject that will move once actions are called")]
    private GameObject _obj;

    //Bools
    [Header("Booleans")]
    [SerializeField]
    [Tooltip("This is a boolean, it gets checked if the player is found. DO NOT TOUCH THIS!!")]
    private bool _playerFound;
    [SerializeField]
    [Tooltip("This is a boolean, it gets checked if the action button is pressed. DO NOT TOUCH THIS!!")]
    private bool _buttonPressed;

    [Header("Vectors")]
    //vector2
    [SerializeField]
    [Tooltip("This is the position where the object will move to.")]
    private Vector2 _moveToValue = new Vector2(0, 0);
    private Vector2 _objToMove;
    
    [Header("Ints and Floats")]
    //ints&floats
    [Tooltip("This is the amount the object will move each step.")]
    [SerializeField]
    private float _movePerStep;

    void Start()
    {
        _objToMove = new Vector2(_obj.transform.position.x, _obj.transform.position.y);
        _moveToValue = new Vector2(_moveToValue.x + _objToMove.x, _moveToValue.y + _objToMove.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision found");
        if (other.gameObject.tag == "Player")
        {
            _playerFound = true;
            Debug.Log("Player found: " + _playerFound);
        }
        else
        {
            _playerFound = false;
        }
    }

    void FixedUpdate()
    {
        //_obj.transform.position = _objToMove;

        if (_playerFound == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _buttonPressed = true;
                Debug.Log("Fire1 Pressed");
            }
        }
        if (_buttonPressed == true)
        {
            StartCoroutine(MoveObject());
        }
    }

    IEnumerator MoveObject()
    {
        for (int i = 0; i < 20; i++)
        {
            _obj.transform.position = Vector2.Lerp(_obj.transform.position, _moveToValue, _movePerStep);
            //yield return new WaitForEndOfFrame();
            yield return new WaitForFixedUpdate();
        }
    }
}
