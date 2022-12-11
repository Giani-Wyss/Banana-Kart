using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackSelector : MonoBehaviour
{
    public void Track1()
    {
        SceneManager.LoadScene("Track1");
    }
    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
