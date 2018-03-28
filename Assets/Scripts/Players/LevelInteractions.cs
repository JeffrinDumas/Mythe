using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInteractions : MonoBehaviour {
    public Movement movement;
    public DoorOpening dooropen;
    public Timers timers;

    private GameObject timer;

    public bool grounded = false;
    public bool walled = false;
    public bool _sticking = false;
    public bool _leftHit = false;
    public bool _rightHit = false;

    void Start () {
        timer = GameObject.FindGameObjectWithTag("TimerHandler");
        timers = timer.GetComponent<Timers>();
        movement = this.GetComponent<Movement>();
        
	}
	

    void LateUpdate()
    {
        if (_sticking == true)
        {
            StartCoroutine(StickAndGlide());

        }
        else if(_sticking == false)
        {
            StopCoroutine(StickAndGlide());
        }
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
           grounded = true;
        }

        foreach (ContactPoint2D hitpos in coll.contacts)
        {
            if (hitpos.normal.x == 1 || hitpos.normal.x == -1 && movement._jumpAmnt == 0)
            {
                movement._jumpAmnt = 1 ;
            } else if (hitpos.normal.y == 1)
            {
                movement._jumpAmnt = 1;
            }

            if(hitpos.normal.x == 1)
            {
                _leftHit = true;
            }
            else if(hitpos.normal.x == -1)
            {
                _rightHit = true;
            }
           
           
        }

        if (coll.gameObject.tag == "Wall")
        {
            walled = true;
            _sticking = true;

            
        }

      if(movement._jumpAmnt > movement._maxJumps)
        {
            movement._jumpAmnt = movement._maxJumps;
        }
   
        
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            grounded = false;
        }

        if (coll.gameObject.tag == "Wall")
        {
            StartCoroutine(JumpWindow());

            if (_leftHit == true || _rightHit == true)
            {
                StartCoroutine(DactivateBool());
            }
        }
    }

    IEnumerator StickAndGlide()
    {
        movement._player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        yield return new WaitForSeconds(0.4f);
        _sticking = false;
    }

    IEnumerator JumpWindow()
    {
        yield return new WaitForSeconds(0.15f);
        walled = false;
    }

    IEnumerator DactivateBool()
    {
        yield return new WaitForSeconds(0.1f);
        _leftHit = false;
        _rightHit = false;
    }

}
