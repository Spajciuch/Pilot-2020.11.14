using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool horizontal, vertical;
    private bool goingUp, goingDown;

    public float range, speed;
    private Vector2 startPosition, lowerPosition, highiestPosition;

    void Start()
    {     
        if (vertical)
        {
            highiestPosition = new Vector2(transform.position.x, transform.position.y + range);
            lowerPosition = new Vector2(transform.position.x, transform.position.y - range);
        }
        else if (horizontal)
        {
            highiestPosition = new Vector2(transform.position.x + range, transform.position.y);
            lowerPosition = new Vector2(transform.position.x - range, transform.position.y);
        }

        goingUp = true;
    }

    void FixedUpdate()
    {
        

        if (vertical)
        {
            if (Vector3.Distance(transform.position, highiestPosition) < 0.1f)
            {
                goingUp = false;
                goingDown = true;
            } 
            else if (Vector3.Distance(transform.position, lowerPosition) < 0.1f)
            {
                goingUp = true;
                goingDown = false;
            }

            if (goingUp) transform.position = Vector3.MoveTowards(transform.position, highiestPosition, speed * Time.deltaTime);
            if (goingDown) transform.position = Vector3.MoveTowards(transform.position, lowerPosition, speed * Time.deltaTime);
        } 

        if (horizontal)
        {
            if (Vector2.Distance(transform.position, highiestPosition) < 0.1f)
            {
                goingUp = false;
                goingDown = true;
            }
            else if (Vector2.Distance(transform.position, lowerPosition) < 0.1f)
            {
                goingUp = true;
                goingDown = false;
            }

            Debug.Log(goingUp + " : " + goingDown);

            if (goingUp) transform.position = Vector3.MoveTowards(transform.position, highiestPosition, speed * Time.deltaTime);
            if (goingDown) transform.position = Vector3.MoveTowards(transform.position, lowerPosition, speed * Time.deltaTime);
        }
    }
}
