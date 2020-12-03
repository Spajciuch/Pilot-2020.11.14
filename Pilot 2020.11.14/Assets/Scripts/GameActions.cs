using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameActions : MonoBehaviour
{
    
    public void PauseGame(bool UI = false)
    {
        if (Time.timeScale == 0) return;

        Time.timeScale = 0;

        if (UI)
        {
            SceneManager.LoadScene("PauseScreen", LoadSceneMode.Additive);
        }
    } 

    public void ResumeGame()
    {
        SceneManager.UnloadSceneAsync("PauseScreen");
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
    bool goingUp = true;
    bool goingDown = false;

    public void Float(GameObject target, Vector2 highiestPosition, Vector2 lowerPosition, float speed)
    {
        if (Vector3.Distance(target.transform.position, highiestPosition) < 0.1f)
        {
            goingUp = false;
            goingDown = true;
        }
        else if (Vector3.Distance(target.transform.position, lowerPosition) < 0.1f)
        {
            goingUp = true;
            goingDown = false;
        }

        if (goingUp) target.transform.position = Vector3.MoveTowards(transform.position, highiestPosition, speed * Time.deltaTime);
        if (goingDown) target.transform.position = Vector3.MoveTowards(transform.position, lowerPosition, speed * Time.deltaTime);
    }
}