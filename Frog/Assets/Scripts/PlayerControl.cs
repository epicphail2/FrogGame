using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Transform form;

    public float speed = 10;
    private BoxCollider2D collide;
    private Transform tongueForm;

    private float angle;

    private Vector2 mousePos;
    private Vector2 tongueMove;
    private Vector2 refVelocity = Vector2.zero;

    Vector2 direction;
    public bool clicked;
    private bool maxRange;

    void Start()
    {
        form = this.GetComponent<Transform>();
        //collide = GameObject.Find("Tongue").GetComponent<BoxCollider2D>();
        tongueForm = GameObject.Find("Tongue").GetComponent<Transform>();
        tongueForm.position = form.position;
        mousePos = form.position;
        direction = form.position;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&!clicked)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            print(mousePos);
            computeDirection();
            clicked = true;
            mousePos.Normalize();
            mousePos.x = mousePos.x* 8.5f;
            mousePos.y = mousePos.y * 8.5f;
        }

        /*
        tongueMove = Vector2.SmoothDamp(tongueForm.position, mousePos, ref refVelocity, 1f);
        tongueForm.position = tongueMove;
        */
       
        if(clicked)
        {
            Vector2 tonguePosBut2D = tongueForm.position;
            if (tonguePosBut2D == mousePos)
            {
                clicked = false;
                print("yeet");
            }
            tongueForm.position = Vector2.MoveTowards(tongueForm.position, mousePos, .1f);
        }
        else if(!clicked && tongueForm.position != form.position)
        {
            tongueForm.position = Vector2.MoveTowards(tongueForm.position, form.position, .1f);
        }
    }
    void computeDirection()
    {
        direction = new Vector2(mousePos.x - form.position.x, mousePos.y - form.position.y);
        print (direction);
    }
}
