using UnityEngine;

public class SmokeController : MonoBehaviour
{
    // Reference to the Particle System (e.g., smoke)
    public ParticleSystem smoke;

    // To track the previous position of the object
    private Vector3 previousPosition;

    // Movement threshold to determine if the object is moving
    public float movementThreshold = 0.01f;

    void Start()
    {
        // Initialize the previous position to the object's initial position
        previousPosition = transform.position;

        // Ensure the smoke particle system is not null
        if (smoke == null)
        {
            Debug.LogError("Smoke Particle System is not assigned.");
        }
    }

    void FixedUpdate()
    {
        // Calculate the distance the object has moved since the last frame
        float distanceMoved = Vector3.Distance(transform.position, previousPosition);

        // Check if the object has moved more than the threshold
        if (distanceMoved > movementThreshold)
        {
            // If the object is moving and the smoke is not already playing, play the smoke
            if (!smoke.isPlaying)
            {
                smoke.Play();
            }
        }
        else
        {
            // If the object is not moving and the smoke is playing, stop the smoke
            if (smoke.isPlaying)
            {
                smoke.Stop();
            }
        }

        // Update the previous position for the next frame
        previousPosition = transform.position;
    }
}
