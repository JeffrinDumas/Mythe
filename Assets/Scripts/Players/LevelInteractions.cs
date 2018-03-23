using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInteractions : MonoBehaviour {
    public Movement movement;
    public DoorOpening dooropen;
    private GameObject door;
    public bool _grounded = false;
    public bool _walled = false;
    private bool _doorOpening = false;
    public int _keys = 0;
    // Use this for initialization
    void Start () {
       movement = this.GetComponent<Movement>();
        door = GameObject.FindGameObjectWithTag("Door");
        dooropen = door.GetComponent<DoorOpening>();
        
	}
	

    void LateUpdate()
    {
        if(_doorOpening == true && _keys > 0)
        {            
            dooropen.SlideDoor();
            _keys--; 
        }
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
           _grounded = true;
        }

        foreach (ContactPoint2D hitpos in coll.contacts)
        {
            // Debug.Log(hitpos.normal);
            if (hitpos.normal.x == 1 || hitpos.normal.x == -1 && movement._jumpAmnt == 0)
            {
                movement._jumpAmnt = 1 ;
            } else if (hitpos.normal.y == 1)
            {
                movement._jumpAmnt = 1;
            }
           
        }

        if (coll.gameObject.tag == "Wall")
        {
            _walled = true;
        }


        if (coll.gameObject.tag == "Door")
        {
            _doorOpening = true;
        }

        if (coll.gameObject.tag == "Key")
        {
            _keys+=1;
            Destroy(coll.gameObject);
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
            _grounded = false;
        }

        if (coll.gameObject.tag == "Wall")
        {
            _walled = false;
        }
    }
}
