using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Extension class to add an IsGrounded method to any Transform
public static class GroundedExtension
{
    // Extension method that checks if the object is touching the ground layer
    public static bool IsGrounded(this Transform transform, LayerMask groundLayer)
    {
        // Creates a point just below the object's position
        // OverlapArea checks if any collider in groundLayer exists at that point
        bool isGrounded = Physics2D.OverlapArea(
            new Vector2(transform.position.x, transform.position.y - 0.5f), // bottom point
            new Vector2(transform.position.x, transform.position.y - 0.5f), // same as top point = single point check
            groundLayer
        );

        // Returns true if something was detected (meaning the player is on the ground)
        return isGrounded;
    }
}
