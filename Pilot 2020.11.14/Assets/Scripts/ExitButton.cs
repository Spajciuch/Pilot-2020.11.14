using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
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
        Application.Quit();
    }
}
