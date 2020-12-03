using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private Button button;
    private GameActions game;
    private GameObject player;

    void Start()
    {
        button = GetComponent<Button>();
        player = GameObject.Find("Player");
        game = player.GetComponent<GameActions>();

        button.onClick.AddListener(TooglePause);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                game.PauseGame(true);
                player.GetComponent<Animator>().enabled = false;
            }

            else 
            {
                game.ResumeGame();
                player.GetComponent<Animator>().enabled = true;
            }
        }
    }

    void TooglePause()
    {
        if (Time.timeScale == 1)
        {
            game.PauseGame(true);
            player.GetComponent<Animator>().enabled = false;
        }

        else
        {
            game.ResumeGame();
            player.GetComponent<Animator>().enabled = true;
        }
    }
}
