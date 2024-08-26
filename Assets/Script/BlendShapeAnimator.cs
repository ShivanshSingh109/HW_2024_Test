using UnityEngine;

public class BlendShapeAnimator : MonoBehaviour
{
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private int blendShapeIndex;
    public float speed = 1.0f;
    private float minBlendValue = 0f;
    private float maxBlendValue = 100f;
    private bool increasing = true;

    void Start()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        blendShapeIndex = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("dance");
        Debug.Log("Found:" + blendShapeIndex);
        if (blendShapeIndex == -1)
        {
            Debug.LogError("Blend shape not found.");
        }
    }

    void FixedUpdate()
    {
        if (blendShapeIndex == -1) return;
        float currentWeight = skinnedMeshRenderer.GetBlendShapeWeight(blendShapeIndex);
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
        skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIndex, currentWeight);
    }
}
