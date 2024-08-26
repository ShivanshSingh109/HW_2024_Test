using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    void Start(){
        Application.targetFrameRate = 60;
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("mainGame");
    }
    public void HomeButton()
    {
        SceneManager.LoadScene("homeScreen");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("mainGame");
    }
    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_STANDALONE
            // Quit the application
            Application.Quit();
        #endif

        // If we are running in the editor
        #if UNITY_EDITOR
            // Stop playing the scene
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
