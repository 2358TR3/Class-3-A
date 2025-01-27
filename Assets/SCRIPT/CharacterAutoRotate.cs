using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAutoRotate : MonoBehaviour
{
    public float rotationAngle = 45f; // The angle to rotate left and right
    public float rotationSpeed = 50f;  // The speed of rotation

    private float currentAngle = 0f;  // Tracks the current angle of rotation
    private int rotationDirection = 1; // 1 for right, -1 for left

    void Update()
    {
        // Calculate the rotation step for this frame
        float rotationStep = rotationSpeed * Time.deltaTime * rotationDirection;

        // Apply the rotation to the object
        transform.Rotate(0f, rotationStep, 0f);

        // Update the current angle
        currentAngle += rotationStep;

        // Check if the rotation exceeds the set limit and reverse direction
        if (Mathf.Abs(currentAngle) >= rotationAngle)
        {
            rotationDirection *= -1; // Reverse direction
        }
    }
}
