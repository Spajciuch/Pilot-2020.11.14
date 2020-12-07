using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private Edek edek;

    private void Update()
    {
        edek = FindObjectOfType<Edek>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        edek.target = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        edek.target = null;
    }
}