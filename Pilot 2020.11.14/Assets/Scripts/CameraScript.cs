using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject player;
    public float cameraDistance;
    void Start()
    {
        player = GameObject.Find("Player");
        transform.position = player.transform.position;
    }

    
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, -cameraDistance);
    }
}
