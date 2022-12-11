using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaceFinished : MonoBehaviour
{
    [SerializeField] Text car1finished;
    [SerializeField] Text car2finished;
    [SerializeField] Text raceisover;

    public CheckpointSys car1;
    public CheckpointSys2 car2;

    private string winner;

    bool raceisfinished = false;
    float currentTime = 0;
    float endTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = endTime;
    }

    // Update is called once per frame
    void Update()
    {
        // check if cars finished
        if (car1.finished && !car2.finished)
        {
            car1finished.text = "Finished!";
            winner = "Player 1";
        } else if (car2.finished && !car1.finished)
        {
            car2finished.text = "Finished!";
            winner = "Player 2";
        }
        else if (car1.finished && car2.finished) // race is over

        {
            raceisover.text = (winner + " won!");
            car1finished.text = null;
            car2finished.text = null;

            raceisfinished = true;
            currentTime -= 1 * Time.deltaTime;
        }
        if (raceisfinished && currentTime < 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
