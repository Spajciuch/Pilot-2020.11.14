using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResumeButton : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ToogleButton);
    }

    void Update()
    {
        
    }

    private void ToogleButton()
    {
        SceneManager.UnloadSceneAsync("PauseScreen");
        Time.timeScale = 1;
        GameObject.Find("Player").GetComponent<Animator>().enabled = true;
    }
}
