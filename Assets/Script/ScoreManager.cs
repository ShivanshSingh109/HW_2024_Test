using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    void Start()
    {
        PlayerPrefs.SetInt("current_score", 0);
        // Load the score from PlayerPrefs (if it exists)
        score = PlayerPrefs.GetInt("current_score", 0); // Default to 0 if "current_score" doesn't exist
        UpdateScoreUI();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("Pulpit_"))
        {
            string pulpitNumberStr = collision.gameObject.name.Replace("Pulpit_", "");
            if (int.TryParse(pulpitNumberStr, out int pulpitScore))
            {
                if (pulpitScore > score)
                {
                    score = pulpitScore;
                    UpdateScoreUI();

                    // Store the updated score in PlayerPrefs
                    PlayerPrefs.SetInt("current_score", score);
                    PlayerPrefs.Save(); // Ensure PlayerPrefs are saved to disk
                }
            }
            else
            {
                Debug.LogError("Failed to convert pulpit number to score.");
            }
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "" + score;
    }
}
