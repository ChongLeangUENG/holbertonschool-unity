using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool isTimerRunning = false;
    private bool playerStartedMoving = false; // Added variable

    private void Start()
    {
        // Disable the Timer script initially
        enabled = false;
    }

    private void Update()
    {
        if (playerStartedMoving) // Check if the player has started moving
        {
            if (isTimerRunning)
            {
                float currentTime = Time.time - startTime;
                string minutes = ((int)currentTime / 60).ToString("D2");
                string seconds = (currentTime % 60).ToString("00.00");
                timerText.text = minutes + ":" + seconds;
            }
        }
    }

    // Method to start the timer
    public void StartTimer()
    {
        startTime = Time.time;
        isTimerRunning = true;
    }

    // Method to indicate that the player has started moving
    public void PlayerStartedMoving()
    {
        playerStartedMoving = true;
    }
}
