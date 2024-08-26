using UnityEngine;
using UnityEngine.UI;

public class CurrentScoreDisplay : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        int currentScore = PlayerPrefs.GetInt("current_score", 0);
        scoreText.text = currentScore.ToString();
    }
}
