using UnityEngine;

public class ExitApplication : MonoBehaviour
{
    // Method to quit the application
    public void QuitGame()
    {
        // If we are running in a standalone build of the game
#if UNITY_STANDALONE
            UnityEngine.Application.Quit();
#endif

        // If we are running in the editor
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
