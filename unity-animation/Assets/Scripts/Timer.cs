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

    public static Timer Instance; // Singleton instance
    public Text finalTimeText; // Assign in inspector, from WinCanvas

    private float elapsedTime = 0f;
    private bool isRunning = true;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


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
            if (isRunning)
                elapsedTime += Time.deltaTime;
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

    public void Win()
    {
        isRunning = false;
        finalTimeText.text = FormatTime(elapsedTime);
    }

    private string FormatTime(float timeToFormat)
    {
        int minutes = (int)(timeToFormat / 60);
        float seconds = timeToFormat % 60f;
        return $"{minutes}:{seconds:00.00}";
    }
}
