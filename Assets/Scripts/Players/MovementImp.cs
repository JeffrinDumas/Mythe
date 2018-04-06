using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementImp : MonoBehaviour {
    public LevelInteractions levelInt;

    public Animator _anim;

    [SerializeField]
    public GameObject _player;

    private float _speedMultiplier = 1.7f;
    private float _speedRuductor = 0.1f;
    private float _maxSpeed = 20f;
    public  Vector2 _currentSpeed;
    public float _speed = 10f;
    private float _jump;
    private float _jumpStr = 8f;

    public int _maxJumps = 1;
    public int _jumpAmnt = 1;


    private Rigidbody2D rby;

    private Vector3 _currentPos;
    public bool isWalking;


    // Use this for initialization
    void Start()
    {
        rby = this.GetComponent<Rigidbody2D>();
        levelInt = this.GetComponent<LevelInteractions>();
    }

    // Update is called once per frame
    void Update()
    {
        _currentSpeed = rby.velocity;


        if (_jumpAmnt > 0 && levelInt.grounded == true || _jumpAmnt > 0 && levelInt.walled == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {

                _jumpAmnt--;
                if (levelInt._leftHit == true)
                {
                    rby.velocity += new Vector2(6, _jumpStr);
                }
                else if (levelInt._rightHit == true)
                {
                    rby.velocity += new Vector2(-6, _jumpStr);
                }
                else
                {
                    rby.velocity = new Vector2(rby.velocity.x, _jumpStr);
                }
                levelInt._sticking = false;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                levelInt._sticking = false;
                

            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                isWalking = true;
              
                rby.position += _currentSpeed;
            }
            else
            {
                isWalking = false;
            }

         
        }
    }

    void ReduceSpeed()
    {
        _currentSpeed = _currentSpeed * _speedRuductor;
    }

    void IncreaseSpeed()
    {
        _currentSpeed *= _speedMultiplier;
    }
}
