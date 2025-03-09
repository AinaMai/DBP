using UnityEngine;
using UnityEngine.SceneManagement; // Include this namespace to use SceneManager

public class SceneChange : MonoBehaviour
{
    // Method to load the "try" scene
    public void LoadTryScene()
    {
        SceneManager.LoadScene("Try");
    }

    // Method to load the "try" scene
    public void LoadVideoScene()
    {
        SceneManager.LoadScene("Video");
    }
    
}

