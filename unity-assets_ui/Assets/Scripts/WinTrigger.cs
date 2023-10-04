using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text timerText; // Reference to the Timer Text object
    public Timer timerScript; // Reference to the Timer script
    public Color winColor = Color.green; // Color to change to when winning
    public int fontSizeIncrease = 60; // Font size increase when winning

    private bool hasWon = false; // Flag to track if the player has won

    private void OnTriggerEnter(Collider other)
    {
        if (!hasWon && other.CompareTag("Player"))
        {
            // Set the flag to prevent multiple wins
            hasWon = true;

            // Stop the timer
            timerScript.enabled = false;

            // Change the text color to green
            timerText.color = winColor;

            // Increase the font size
            timerText.fontSize += fontSizeIncrease;
        }
    }
}
