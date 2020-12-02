using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActions : MonoBehaviour
{
    
    public void PauseGame()
    {
        Time.timeScale = 0;
    } 

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void Kill(GameObject killObject, bool zoom, bool animation, bool destroy)
    {
        Animator anim = killObject.GetComponent<Animator>();
        CameraScript cameraScript = FindObjectOfType<CameraScript>();

        if (zoom) cameraScript.cameraDistance = 20;
        if (animation) anim.SetBool("Dead", true);
        if (destroy) killObject.SetActive(false);

        PauseGame();
    }

    public void Respawn(GameObject respawnObject, Vector2 position, bool zoom, bool animation, bool create)
    {
        ResumeGame();

        Animator anim = respawnObject.GetComponent<Animator>();
        CameraScript cameraScript = FindObjectOfType<CameraScript>();

        if (zoom) cameraScript.cameraDistance = 50;
        if (animation) anim.SetBool("Dead", false);
        if (create) respawnObject.SetActive(true);

        respawnObject.transform.position = position;
    }
}
