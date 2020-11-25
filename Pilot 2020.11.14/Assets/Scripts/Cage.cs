using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    Wincent wincent;
    Player player;

    void Start()
    {
        wincent = FindObjectOfType<Wincent>();
        player = FindObjectOfType<Player>();
    }

    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log(player.keyNumber);

            if(player.keyNumber >= 1)
            {
                player.keyNumber--;

                wincent.gameObject.transform.parent = null;

                gameObject.SetActive(false);
                wincent.owner = player.gameObject;
            }
        }
    }
}
