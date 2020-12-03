using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edek : MonoBehaviour
{
    public float range, speed;
    
    public GameObject target;
    private GameActions game;

    Vector2 highiestPosition, lowerPosition;

    void Start()
    {
        highiestPosition = new Vector2(transform.position.x, transform.position.y + range);
        lowerPosition = new Vector2(transform.position.x, transform.position.y - range);

        game = gameObject.AddComponent<GameActions>();
    }


    void FixedUpdate()
    {
        Movement();   
    }

    private void Movement()
    {
        if (target == null)
        {
            game.Float(gameObject, highiestPosition, lowerPosition, speed);
        }
    }
}
