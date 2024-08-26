using UnityEngine;
using UnityEngine.UI;

public class CurrentScoreDisplay : MonoBehaviour
{
    public Text scoreText; // Reference to the Text UI component

    void Start()
    {
        // Load the current score from PlayerPrefs
        int currentScore = PlayerPrefs.GetInt("current_score", 0);
        
        // Update the Text UI element with the current score
        scoreText.text = currentScore.ToString();
    }
}
