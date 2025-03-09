using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBackground : MonoBehaviour
{
    public Transform player;           // Reference to the player's Transform
    public BoxCollider2D backgroundCollider; // Reference to the background collider
    public float smoothSpeed = 0.125f; // Smoothness of the camera movement
    public Vector3 offset;            // Offset to keep the camera at a fixed distance from the player

    private Vector3 minBounds;        // Minimum bounds of the background (camera can’t go below this)
    private Vector3 maxBounds;        // Maximum bounds of the background (camera can’t go beyond this)

    void Start()
    {
        // Get the bounds of the background
        if (backgroundCollider != null)
        {
            minBounds = backgroundCollider.bounds.min;
            maxBounds = backgroundCollider.bounds.max;
        }
    }

    void LateUpdate()
    {
        // Calculate the desired position of the camera based on the player's position + offset
        Vector3 desiredPosition = player.position + offset;

        // Ensure the camera only follows the player vertically (Y-axis or Z-axis)
        desiredPosition.x = transform.position.x; // Lock the X position (no left/right movement)
        
        // Optional: Clamp the vertical position if you want the camera to stay within bounds vertically.
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y + offset.y, maxBounds.y + offset.y);
        Vector3 clampedPosition = new Vector3(desiredPosition.x, clampedY, transform.position.z);

        // Smoothly move the camera to the clamped position
        transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);
    }
}




