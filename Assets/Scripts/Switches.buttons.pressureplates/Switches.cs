using System.Collections;
using UnityEngine;

/// <summary>
/// This script is to handle the switches, buttons and pressure plates.
/// drag the object you want to move into the gameobject slot in the inspector
/// </summary>

public class Switches : MonoBehaviour
{

    [Header("GameObject")]
    [SerializeField]
    [Tooltip("This is the gameobject that will move once actions are called")]
    private GameObject _obj;
    [SerializeField]
    [Tooltip("Only check this boolean if it's a pressure plate and not a switch, or button.")]
    private bool _pressurePlate;

    [Header("Movement")]
    [SerializeField]
    [Tooltip("This is the position where the object will move to.")]
    private Vector2 _moveToValue = new Vector2(0, 0);
    [Tooltip("This is the amount the object will move each step.")]
    [SerializeField]
    private float _movePerStep;

    private bool _playerFound;
    private bool _buttonPressed;

    private Vector2 _previousLocation = new Vector2(0, 0);

    void Start()
    {
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
