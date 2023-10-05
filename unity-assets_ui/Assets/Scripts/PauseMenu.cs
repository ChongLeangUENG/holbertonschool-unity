using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;  // Assign your PauseCanvas prefab in the Inspector.
    private bool isPaused = false;  // Track whether the game is paused.
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseCanvas.SetActive(true);  // Activate the PauseCanvas.
        Time.timeScale = 0f;  // Pause the game by setting the time scale to 0.
        isPaused = true;
    }

    public void Resume()
    {
        pauseCanvas.SetActive(false);  // Deactivate the PauseCanvas.
        Time.timeScale = 1f;  // Resume the game by setting the time scale back to 1.
        isPaused = false;
    }
}
