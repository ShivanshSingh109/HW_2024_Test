using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class GameOver : MonoBehaviour
{
    private float yThreshold = 0.5f; // Y position threshold for game over

    void FixedUpdate()
    {
        // Check if the player's y position is below the threshold
        if (transform.position.y < yThreshold)
        {
            // Load the specified scene
            SceneManager.LoadScene("gameOver");
        }
    }
}
