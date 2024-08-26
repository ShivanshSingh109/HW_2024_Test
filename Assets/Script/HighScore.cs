using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreText; // Reference to the Text UI component

    void Start()
    {
        // Get the current score from PlayerPrefs
        int currentScore = PlayerPrefs.GetInt("current_score", 0);

        // Get the existing high score from PlayerPrefs
        int highScore = PlayerPrefs.GetInt("high_score", 0);

        // Check if the current score is greater than the high score
        if (currentScore > highScore)
        {
            // Update the high score with the current score
            PlayerPrefs.SetInt("high_score", currentScore);

            // Optionally, save the PlayerPrefs to ensure the change is persisted
            PlayerPrefs.Save();
            
            highScore = currentScore; // Update the local high score variable
        }
        else
        {
            Debug.Log("Current score did not beat the high score.");
        }

        // Update the Text UI element with the high score
        highScoreText.text = highScore.ToString();
    }
}
