using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public LevelInteractions levelInt;

    [SerializeField]
    private GameObject _player;

    private float _maxSpeed;
    private float _currentSpeed = 10f;
    private float _jump;
    private float _jumpStr = 8f;

    public int _maxJumps = 1;
    public int _jumpAmnt = 1;


    private Rigidbody2D rby;

    private Vector3 _currentPos;

    // Use this for initialization
    void Start()
    {
        rby = gameObject.GetComponent<Rigidbody2D>();
        levelInt = this.GetComponent<LevelInteractions>();
    }

    // Update is called once per frame
    void Update()
    {
    

        if(_jumpAmnt > 0 && levelInt._grounded == true || levelInt._walled == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                rby.velocity = new Vector2(rby.velocity.x, _jumpStr);
                _jumpAmnt--;
            }
        }
	}

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");

        rby.AddForce((Vector2.right * _currentSpeed) * x);
    }


}
