using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LevelSelect(int level)
    {
        // Check if level index is valid
        if (level >= 0 && level < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(level);
        }
        else
        {
            Debug.LogError("Invalid level index");
        }
    }

    public void Options()
    {
        // Load the Options scene
        SceneManager.LoadScene("Options");
    }

    public void ExitButton()
    {
        // Log exit message and close the game
        Debug.Log("Exited");
        Application.Quit();
    }
}
