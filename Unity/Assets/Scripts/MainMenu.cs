using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("TrackSelector");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Instructions()
    {
        Application.OpenURL("https://bananakart.gianmarco-wyss.bbzwinf.ch/How%20To%20Play/");
    }
}
