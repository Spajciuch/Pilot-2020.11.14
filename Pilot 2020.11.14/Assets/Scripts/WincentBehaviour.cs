using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WincentBehaviour : MonoBehaviour
{
    public float speed, size;

    private GameObject player;
    private bool belongs = false;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 3) belongs = true;

        if (belongs)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            float playerX = player.transform.position.x;
            float ownX = transform.position.x;

            if(playerX > ownX)
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
