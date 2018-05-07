﻿  using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaycastCollission : MonoBehaviour {
    public LayerMask groundLayer;
    public Animator _anim;
    // Use this for initialization
    public float rayDistance;

    public List<GameObject> rayPoints;
    public List<Ray2D> rays;
    public List<Ray2D> raysDown;
    public List<Ray2D> raysLeft;
    public List<Ray2D> raysRight;

    public RaycastHit2D TileHit;
    public bool showRays;

    public bool collisionDown;
    public bool collisionLeft;
    public bool collisionRight;
    private bool _isGrounded;
    
    

    void Start()
    {
        rayPoints = new List<GameObject>();
        getRays();
        _anim.GetComponent<Animator>();
    }

    void Update()
    {
        
        checkCollision();

        if (showRays)
        {
            drawRaycast();
        }
            
    }

    void getRays()
    {
        List<GameObject> children = gameObject.GetChildren();

        List<GameObject> children2 = new List<GameObject>();

        for (int i = 0; i < children.Count; i++)
        {
            if (children[i].name == "RayCasting")
                children2 = children[i].GetChildren();
        }

        for (int i = 0; i < children2.Count; i++)
        {
            //Debug.Log(i + " " + children2[i].gameObject.name);
            rayPoints.Add(children2[i]);
        }
    }

    void checkCollision()
    {
        List<Ray2D> raysDown = new List<Ray2D>();
        List<Ray2D> raysLeft = new List<Ray2D>();
        List<Ray2D> raysRight = new List<Ray2D>();

        TileHit = new RaycastHit2D();

        for (int i = 0; i < rayPoints.Count; i++)
        {
            if (rayPoints[i].gameObject.name == "down")
            {
                raysDown.Add(new Ray2D(new Vector2(rayPoints[i].gameObject.transform.position.x, rayPoints[i].gameObject.transform.position.y), -Vector2.up));
            }

            if (rayPoints[i].gameObject.name == "left")
            {
                raysLeft.Add(new Ray2D(new Vector2(rayPoints[i].gameObject.transform.position.x, rayPoints[i].gameObject.transform.position.y), -Vector2.right));
            }

            if (rayPoints[i].gameObject.name == "right")
            {
                raysRight.Add(new Ray2D(new Vector2(rayPoints[i].gameObject.transform.position.x, rayPoints[i].gameObject.transform.position.y), Vector2.right));
            }
        }

        collisionDown = checkCollision(raysDown);
        collisionLeft = checkCollision(raysLeft);
        collisionRight = checkCollision(raysRight);

    }

    void drawRaycast()
    {
        for (int i = 0; i < rayPoints.Count; i++)
        {
            if (rayPoints[i].gameObject.name == "down")
                Debug.DrawLine(rayPoints[i].gameObject.transform.position, new Vector3(rayPoints[i].gameObject.transform.position.x, rayPoints[i].gameObject.transform.position.y - rayDistance, rayPoints[i].gameObject.transform.position.z), Color.red);

            if (rayPoints[i].gameObject.name == "left")
                Debug.DrawLine(rayPoints[i].gameObject.transform.position, new Vector3(rayPoints[i].gameObject.transform.position.x - rayDistance, rayPoints[i].gameObject.transform.position.y, rayPoints[i].gameObject.transform.position.z), Color.red);

            if (rayPoints[i].gameObject.name == "right")
                Debug.DrawLine(rayPoints[i].gameObject.transform.position, new Vector3(rayPoints[i].gameObject.transform.position.x + rayDistance, rayPoints[i].gameObject.transform.position.y, rayPoints[i].gameObject.transform.position.z), Color.red);
        }

       
    }

    bool checkCollision(List<Ray2D> rayList)
    {
        for (int i = 0; i < rayList.Count; i++)
        {
            TileHit = Physics2D.Raycast(rayList[i].origin, rayList[i].direction, rayDistance + .001f);

            if (TileHit != null && TileHit.collider != null)
            {
                return true;
            }
        }
        return false;
    }

}
