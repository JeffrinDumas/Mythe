using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowUI : MonoBehaviour {
    

    [SerializeField]
    Canvas messageCanvas;

    
    //Turns the canvas off at the start.
    void Start()
    {
        
        messageCanvas.enabled = false;

    }
    //Turns canvas on when player Collides with collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {  
            MessageShow();
        }
    }

    public void MessageShow()
    {

        messageCanvas.enabled = true;
        
    }
    
    //Turns canvas off when player leaves collider.
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            MessageHide();
        }
    }

    public void MessageHide()
    {
        messageCanvas.enabled = false;
    }
}
