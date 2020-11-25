using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wincent : MonoBehaviour
{
    public float speed, size;

    public GameObject owner;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (owner != null)
        {
            float playerDirection = owner.transform.localScale.x;

            Vector2 targetPosition = new Vector2(owner.transform.position.x - playerDirection, owner.transform.position.y + 2);


            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            float playerX = owner.transform.position.x - playerDirection;
            float ownX = transform.position.x;

            if (playerX != ownX)
            {

                if (playerX > ownX)
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
}
