using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckpointSys2 : MonoBehaviour
{
    [Header("Points")]
    public GameObject start;
    public GameObject end;
    public GameObject[] checkpoints;

    [Header("Settings")]
    public float laps = 5;

    [Header("Information")]
    private float currentCheckpoint;
    static public float currentLap2;
    private bool started;
    public bool finished;

    private void Start()
    {
        currentCheckpoint = 0;
        currentLap2 = 1;
        
        started = false;
        finished = false;
    }

    private void Update(){}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            GameObject thisCheckpoint = other.gameObject;

            // Started the race
            if (thisCheckpoint == start && !started)
            {
                print("CAR2 Started");
                started = true;
            }
            // Ended the lap or race
            else if (thisCheckpoint == end && started)
            {
                // If all the laps are finished, end the race
                if (currentLap2 == laps)
                {
                    if (currentCheckpoint == checkpoints.Length)
                    {

                        finished = true;
                        print("CAR2 Finished");
                    }
                    else
                    {
                        print("CAR2 did not go through all checkpoints");
                    }
                }
                // If all laps are not finished, start a new lap
                else if (currentLap2 < laps)
                {
                    if (currentCheckpoint == checkpoints.Length)
                    {

                        currentLap2++;
                        currentCheckpoint = 0;
                        print($"CAR2 Started lap {currentLap2}");
                    }
                    else
                    {
                        print("CAR2 Did not go through all checkpoints");
                    }
                }
            }

            // Loop through the checkpoints to compare and check which one the player touched
            for (int i = 0; i < checkpoints.Length; i++)
            {
                if (finished)
                    return;

                // If the checkpoint is correct
                if (thisCheckpoint == checkpoints[i] && i + 1 == currentCheckpoint + 1)
                {
                    print($"CAR2 Correct Checkpoint");
                    currentCheckpoint++;
                }
                // If the checkpoint is incorrect
                else if (thisCheckpoint == checkpoints[i] && i + 1 != currentCheckpoint + 1)
                {
                    print($"CAR2 Incorrect checkpoint");
                }
            }
        }
    }
}