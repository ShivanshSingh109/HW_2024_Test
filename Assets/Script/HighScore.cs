using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreText;

    void Start()
    {
        int currentScore = PlayerPrefs.GetInt("current_score", 0);
        int highScore = PlayerPrefs.GetInt("high_score", 0);

        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("high_score", currentScore);
            PlayerPrefs.Save();
            highScore = currentScore;
        }
        else
        {
            Debug.Log("Current score did not beat the high score.");
        }
        highScoreText.text = highScore.ToString();
    }
}
