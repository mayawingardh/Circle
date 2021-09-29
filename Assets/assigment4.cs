using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assigment4 : ProcessingLite.GP21
{
    public Vector2 circlePosition;
    public float diameter;
    Vector2 velocity;

    void Start()
    {
        Background(216, 191, 216);
        Stroke(255, 255, 0);
        StrokeWeight(1.2f);
        Fill(216, 191, 216);
        diameter = 2;
        circlePosition = new Vector2(Width / 2, Height / 2);
    }
    void Update()
    {
        //The circle
        Background(216, 191, 216);
        Circle(circlePosition.x, circlePosition.y, diameter);
        circlePosition += velocity*Time.deltaTime;

        //Draw a line
        if (Input.GetMouseButton(0)) //körs en gång när man klickar

        {
            Stroke(255, 255, 0);
            StrokeWeight(1.2f);
            Line(circlePosition.x, circlePosition.y, MouseX, MouseY);                 
        }

        //Move circle
        if (Input.GetMouseButtonDown(0)) // när man trycket, körs en frame
        {
            Vector2 mousePos = new Vector2(MouseX, MouseY);
            circlePosition = mousePos;
        }

        //Give velocity to circle 
        if (Input.GetMouseButtonUp(0)) //när man släpper, körs en frame
        {
            velocity = new Vector2(MouseX-circlePosition.x,MouseY-circlePosition.y);
        }    
            Bounce();
    }
    //Method to make the ball bounce
    private void Bounce()
    {
        if (circlePosition.x > Width || circlePosition.x < 0 )
        {
            velocity.x *= -1;
            
        }

        if (circlePosition.y > Height || circlePosition.y < 0)
        {
            velocity.y *= -1;
        }
    }
}
