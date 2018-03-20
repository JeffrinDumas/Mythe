using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInteractions : MonoBehaviour {
    public Movement movement;
    public DoorOpening dooropen;
    private GameObject door;
    private bool _grounded = false;
    private bool _walled = false;
    private bool _doorOpening = false;
    public int _keys = 0;
    // Use this for initialization
    void Start () {
       movement = this.GetComponent<Movement>();
        door = GameObject.FindGameObjectWithTag("Door");
        dooropen = door.GetComponent<DoorOpening>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
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
            movement._jumpAmnt = 1;
        }

        if (coll.gameObject.tag == "Wall" && movement._jumpAmnt == 0)
        {
            movement._jumpAmnt++;
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
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            _grounded = false;
        }
    }
}
