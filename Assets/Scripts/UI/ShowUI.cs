using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowUI : MonoBehaviour {

    [SerializeField]
    Canvas messageCanvas;

    void Start()
    {

        messageCanvas.enabled = false;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            MessageShow();
        }
    }

    public void MessageShow()
    {
        messageCanvas.enabled = true;
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            MessageHide();
        }
    }

    public void MessageHide()
    {
        messageCanvas.enabled = false;
    }
}
