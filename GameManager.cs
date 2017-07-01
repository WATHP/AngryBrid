using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Transform firstBg;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void Restartonclick()
    {
        SceneManager.LoadScene("Start");
    }
}
