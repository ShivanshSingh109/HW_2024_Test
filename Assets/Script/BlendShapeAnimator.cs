using UnityEngine;

public class BlendShapeAnimator : MonoBehaviour
{
    // Reference to the SkinnedMeshRenderer component
    private SkinnedMeshRenderer skinnedMeshRenderer;

    // Blend shape index for the "dance" blend shape
    private int blendShapeIndex;

    // Speed at which the blend shape value changes
    public float speed = 1.0f;

    // Range for the blend shape values (0 to 100)
    private float minBlendValue = 0f;
    private float maxBlendValue = 100f;

    // Direction for the blend shape value change
    private bool increasing = true;

    void Start()
    {
        // Get the SkinnedMeshRenderer component attached to this GameObject
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

        // Find the index of the "dance" blend shape
        blendShapeIndex = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("dance");
        Debug.Log("Found:" + blendShapeIndex);
        // Check if the blend shape exists
        if (blendShapeIndex == -1)
        {
            Debug.LogError("Blend shape 'dance' not found.");
        }
    }

    void FixedUpdate()
    {
        // If the blend shape doesn't exist, exit the method
        if (blendShapeIndex == -1) return;

        // Get the current blend shape weight
        float currentWeight = skinnedMeshRenderer.GetBlendShapeWeight(blendShapeIndex);

        // Update the blend shape weight based on the direction
        if (increasing)
        {
            currentWeight += speed * Time.deltaTime;
            if (currentWeight >= maxBlendValue)
            {
                currentWeight = maxBlendValue;
                increasing = false;
            }
        }
        else
        {
            currentWeight -= speed * Time.deltaTime;
            if (currentWeight <= minBlendValue)
            {
                currentWeight = minBlendValue;
                increasing = true;
            }
        }

        // Apply the updated blend shape weight
        skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIndex, currentWeight);
    }
}
