using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;
    private string previousSceneName;

    private void Start()
    {
        // Retrieve previous scene name from PlayerPrefs
        previousSceneName = PlayerPrefs.GetString("previousScene", "MainMenu");

        // Initialize the toggle based on saved preference
        invertYToggle.isOn = PlayerPrefs.GetInt("isYAxisInverted", 0) == 1;
    }

    public void Apply()
    {
        // Save the inverted Y axis preference
        PlayerPrefs.SetInt("isYAxisInverted", invertYToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();

        // Return to previous scene
        SceneManager.LoadScene(previousSceneName);
    }
    public void Back()
    {
        // If there's a previously loaded scene, go back to it
        if (SceneManager.sceneCount >= 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
        {
            Debug.LogError("No previous scene to load");
        }
    }
}
