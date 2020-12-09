using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDetect : MonoBehaviour
{
    private GameActions game;

    private void Start()
    {
        game = gameObject.AddComponent<GameActions>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") game.Kill(GameObject.Find("Edek"), false, false, true);
    }
}
