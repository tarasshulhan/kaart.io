﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceland : MonoBehaviour {

    [SerializeField]
    private Transform icelandPlace;

    private Vector2 initialPosition;

    private Vector2 mousePosition;
    
    private float deltaX, deltaY;  

    public static bool locked;

    public SpriteRenderer spriteRen;

    // Use this for initialization
    void Start ()
    {
        initialPosition = transform.position;
        spriteRen = GetComponent<SpriteRenderer> ();
	}

    private void OnMouseDown()
    {
        if (!locked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (!locked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - icelandPlace.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - icelandPlace.position.y) <= 0.5f)
        {
            transform.position = new Vector2(icelandPlace.position.x, icelandPlace.position.y);
            locked = true;
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }

    private void Update()
    {
        if (locked){
            spriteRen.sortingOrder = 4;
        }
        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;

                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    break;

                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - icelandPlace.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - icelandPlace.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(icelandPlace.position.x, icelandPlace.position.y);
                        locked = true;
                    }
                    else
                    {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                    }
                    break;
            }
        }
    }    
}
