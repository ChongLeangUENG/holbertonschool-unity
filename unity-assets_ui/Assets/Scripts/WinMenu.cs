using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void MainMenu()
    {
        // Load the MainMenu scene
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        // Get current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Check if the next scene is available
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            // Load the next scene
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            // If not, load the MainMenu scene
            MainMenu();
        }
    }
}
