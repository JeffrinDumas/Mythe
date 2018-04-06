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

    [Header("GameObject")]
    [SerializeField]
    [Tooltip("This is the gameobject that will move once actions are called")]
    private GameObject _obj;

    [Header("Booleans")]
    [SerializeField]
    [Tooltip("This is a boolean, it gets checked if the player is found. DO NOT TOUCH THIS!!")]
    private bool _playerFound;
    [SerializeField]
    [Tooltip("This is a boolean, it gets checked if the action button is pressed. DO NOT TOUCH THIS!!")]
    private bool _buttonPressed;
    [Space]
    [SerializeField]
    [Tooltip("Only check this boolean if it's a pressure plate and not a switch, or button.")]
    private bool _pressurePlate;
    [SerializeField]
    [Tooltip("Only check this when it's a moving platform that moves on the horizontal axis.")]
    private bool _movingPlatformHorizontal;

    [Header("Vectors")]
    [SerializeField]
    [Tooltip("This is the position where the object will move to.")]
    private Vector2 _moveToValue = new Vector2(0, 0);
    private Vector2 _previousLocation = new Vector2(0, 0);
    private Vector2 _objToMove;

    [Header("Numbers")]
    [Tooltip("This is the amount the object will move each step.")]
    [SerializeField]
    private float _movePerStep;

    void Start()
    {
        _objToMove = new Vector2(_obj.transform.localPosition.x, _obj.transform.localPosition.y);
        _moveToValue = new Vector2(_moveToValue.x, _moveToValue.y);
        _previousLocation = new Vector2(_obj.transform.localPosition.x, _obj.transform.localPosition.y);
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

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerFound = false;
            Debug.Log("Player found: " + _playerFound);
        }
    }

    void FixedUpdate()
    {
        if (_pressurePlate != true)
        {
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
        else
        {
            if (_playerFound == true)
            {
                StartCoroutine(MoveObject());
            }
            else
            {
                StartCoroutine(ReturnObject());
            }
        }
        
    }

    IEnumerator MoveObject()
    {
        for (int i = 0; i < 20; i++)
        {
            _obj.transform.position = Vector2.Lerp(_obj.transform.localPosition, _moveToValue, _movePerStep);
            yield return new WaitForFixedUpdate();
        }
    }
    
    IEnumerator ReturnObject()
    {
        for (int i = 0; i < 20; i++)
        {
            _obj.transform.position = Vector2.Lerp(_obj.transform.localPosition, _previousLocation, _movePerStep);
            yield return new WaitForFixedUpdate();
        }
    }
}
