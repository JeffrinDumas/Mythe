﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInteractions : MonoBehaviour
{
    public NewMovement movement;
    public Timers timers;
    public RaycastCollission raycast;
    public Animator _anim;

    private GameObject timer;
    private GameObject raycaster;


    public bool grounded = false;
    public bool walled = false;
    public bool _sticking = false;
    public bool _leftHit = false;
    public bool _rightHit = false;

    public bool _isFalling;
    public bool _walled;


    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("TimerHandler");
        timers = timer.GetComponent<Timers>();
        movement = this.GetComponent<NewMovement>();
        raycast = this.GetComponent<RaycastCollission>();
        _anim.GetComponent<Animator>();

    }

    void Update()
    {
        _anim.SetBool("isGrounded", grounded);
        _anim.SetBool("isWalled", _walled);
        _anim.SetBool("isFalling", _isFalling);

        if (raycast.collisionDown == true)
        {
            grounded = true;
        } else
        {
            grounded = false;
        }

        if (raycast.collisionLeft == true || raycast.collisionRight == true && raycast.collisionDown == false)
        {
           
            
                _walled = true;
            }
            else
            {
                _walled = false;
            
            
        }
    
            

        if(raycast.collisionDown == false && raycast.collisionLeft == false && raycast.collisionRight == false)
        {
            _isFalling = true;
        }
        else
        {
            _isFalling = false;
        }
    }

    void LateUpdate()
    {
        if (_sticking == true)
        {
            StartCoroutine(timers.StickAndGlide());

        }
        else if (_sticking == false)
        {
            StopCoroutine(timers.StickAndGlide());
        }

     
    }    

    void OnCollisionEnter2D(Collision2D coll)
    {
    

        foreach (ContactPoint2D hitpos in coll.contacts)
        {
            if (hitpos.normal.x >= 0.7f || hitpos.normal.x <= -0.7f && movement._jumpAmnt == 0)
            {
                movement._jumpAmnt = 1;
            }
            else if (hitpos.normal.y >= 0.05 && coll.gameObject.tag != "Player")
            {
                movement._jumpAmnt = 1;
            }
   
            if (hitpos.normal.x >= 0.7 && coll.gameObject.tag != "Player")
            {
                _sticking = true;
                _leftHit = true;
            }
            else if (hitpos.normal.x <= -0.7 && coll.gameObject.tag != "Player")
            {
                _sticking = true;
                _rightHit = true;
            }
        }

        if (movement._jumpAmnt > movement._maxJumps)
        {
            movement._jumpAmnt = movement._maxJumps;
        }


    }

    void OnCollisionExit2D(Collision2D coll)
    {
       

        if (coll.gameObject.tag == "Wall")
        {
            StartCoroutine(timers.JumpWindow());

            if (_leftHit == true || _rightHit == true)
            {
                StartCoroutine(timers.DactivateBool());
            }
        }
    }
}