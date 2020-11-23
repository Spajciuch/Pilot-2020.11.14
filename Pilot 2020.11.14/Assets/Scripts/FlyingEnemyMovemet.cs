using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMovemet : MonoBehaviour
{
    private GameObject player;
    public GameObject self;

    public float speed, size, detectionRange;
    private bool triggered = false;
    void Start()
    {
        player = GameObject.Find("Player");
    }


    void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= detectionRange) triggered = true;

        if (triggered)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            float playerX = player.transform.position.x;
            float objectX = transform.position.x;

            if (playerX > objectX)
            {
                transform.localScale = new Vector2(-size, size);
            }
            else
            {
                transform.localScale = new Vector2(size, size);
            }
        }
    }
}
