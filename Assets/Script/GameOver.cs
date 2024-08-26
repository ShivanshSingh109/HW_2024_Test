using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private float yThreshold = 0.5f;

    void FixedUpdate()
    {
        if (transform.position.y < yThreshold)
        {
            // Load scene
            SceneManager.LoadScene("gameOver");
        }
    }
}
