using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public void QuitAction()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void PlayAction()
    {
        Debug.Log("play!");
        SceneManager.LoadScene("1setembre");
    }
}
