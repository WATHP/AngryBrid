using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour {

    public Canvas QuitCanvas;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitCanvas.enabled = true;
        }
    }

    public void gameStartClick()
    {
        SceneManager.LoadScene("Start");
    }

    public void yesClick()
    {
        Application.Quit();
    }

    public void noClick()
    {
        QuitCanvas.enabled = false;
    }
}
