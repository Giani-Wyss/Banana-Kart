using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    float currentTime = 0;
    float startingTime = 10;

    [SerializeField] Text countdownText;

    public bool raceingisallowed = false;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {   
        //is done once a Second
        currentTime -= 1 * Time.deltaTime;

        //Check if Countdown is finished
        switch (currentTime)
        {
            case > 0: countdownText.text = currentTime.ToString("0"); break;
            case < -1: countdownText.text = null; raceingisallowed = true; break;
            default: countdownText.text = "GO"; raceingisallowed = true; break;
        }
    }
}