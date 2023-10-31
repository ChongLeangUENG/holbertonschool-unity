using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;

    private bool isPaused = false;

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
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1f;  // Ensure the game isn't paused.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reload the current scene.
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;  // Ensure the game isn't paused.
        SceneManager.LoadScene("MainMenu");  // Replace with your main menu scene name.
    }

    public void Options()
    {
        Time.timeScale = 1f;  // Ensure the game isn't paused.
        SceneManager.LoadScene("Options");  // Replace with your options scene name.
    }
}
