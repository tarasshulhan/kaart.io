using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greece : MonoBehaviour {

    [SerializeField]
    private Transform greecePlace;

    private Vector2 initialPosition;

    private Vector2 mousePosition;
    
    private float deltaX, deltaY;  

    public static bool locked;

    public SpriteRenderer spriteRen;

    //initialization
    void Start ()
    {
        initialPosition = transform.position;
        spriteRen = GetComponent<SpriteRenderer> ();
        GetComponent<BoxCollider2D>().enabled = false;
        spriteRen.sortingOrder = 0;
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
        if (Mathf.Abs(transform.position.x - greecePlace.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - greecePlace.position.y) <= 0.5f)
        {
            transform.position = new Vector2(greecePlace.position.x, greecePlace.position.y);
            locked = true;
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }

    private void Update()
    {
        if (Macedonia.locked){
            spriteRen.sortingOrder = 5;
            GetComponent<BoxCollider2D>().enabled = true;
        }
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
                    if (Mathf.Abs(transform.position.x - greecePlace.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - greecePlace.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(greecePlace.position.x, greecePlace.position.y);
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
