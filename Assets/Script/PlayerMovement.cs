using UnityEngine;
using System.IO;

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    public Transform playerModel;
    public float tiltAngle = 15f;

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

        if (movement.magnitude > 0.1f)
        {
            Vector3 direction = new Vector3(movement.x, 0.0f, movement.z);
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            targetRotation *= Quaternion.Euler(-movement.z * tiltAngle, 0, movement.x * tiltAngle);
            playerModel.rotation = Quaternion.Slerp(playerModel.rotation, targetRotation, Time.deltaTime * 10f);
        }
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
