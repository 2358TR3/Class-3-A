using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveBackAndForth : MonoBehaviour
{
    public float moveDistance = 5f;   // The distance to move back and forth
    public float moveSpeed = 2f;      // Speed of movement

    private Vector3 startPosition;    // Starting position of the character
    private Vector3 targetPosition;   // Target position to move to
    private int moveDirection = 1;    // 1 for moving forward, -1 for moving backward

    void Start()
    {
        // Store the starting position of the character
        startPosition = transform.position;

        // Set the initial target position
        targetPosition = startPosition + new Vector3(moveDistance, 0f, moveDistance);
    }

    void Update()
    {
        // Move the character towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if the character has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Reverse the movement direction
            moveDirection *= -1;

            // Update the target position
            targetPosition = startPosition + new Vector3(moveDirection * moveDistance, 0f, moveDistance);
        }
    }
}

