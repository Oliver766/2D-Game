using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Reference to the player's transform
    public Transform player;

    // Offset of the camera from the player
    public Vector3 offset;

    // Smooth speed of the camera movement
    public float smoothSpeed = 0.125f;

    // Constraints for vertical camera movement (optional)
    public bool constrainVerticalMovement = true;
    public float minY = 0f;
    public float maxY = 10f;

    void FixedUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("Player Transform is not assigned in the SideScrollFollowCamera script.");
            return;
        }

        // Desired position of the camera
        Vector3 desiredPosition = player.position + offset;

        // Constrain the vertical position if enabled
        if (constrainVerticalMovement)
        {
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
        }

        // Smoothly interpolate between the camera's current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera's position to the smoothed position
        transform.position = smoothedPosition;
    }
}
