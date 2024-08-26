using UnityEngine;
using System.IO;

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    public Transform playerModel; // Reference to the player model's transform
    public float tiltAngle = 15f; // The angle of tilt

    void Start()
    {
        string filePath = Application.dataPath + "/doofus_diary.json";
        if (File.Exists(filePath))
        {
            speed = JsonUtility.FromJson<PlayerData>(File.ReadAllText(filePath)).player_data.speed;
        }
        else
        {
            Debug.LogError("The file is missing!");
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        if (movement.magnitude > 0.1f) // Only rotate if there's significant movement
        {
            // Calculate the target direction and constrain it to the Y-axis
            Vector3 direction = new Vector3(movement.x, 0.0f, movement.z);
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

            // Apply a tilt based on the movement direction
            targetRotation *= Quaternion.Euler(-movement.z * tiltAngle, 0, movement.x * tiltAngle);

            // Apply smooth rotation to the player model
            playerModel.rotation = Quaternion.Slerp(playerModel.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // Move the player
        transform.Translate(movement * speed * Time.deltaTime * 3, Space.World);
    }
}

[System.Serializable]
public class PlayerData
{
    public Player player_data;
}

[System.Serializable]
public class Player
{
    public float speed;
}
