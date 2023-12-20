using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GKDraggable : MonoBehaviour
{
    private bool isDragging = false;	// Internal boolean that keeps track of movement for use in the Update method
    private Vector3 offset;   		// Internal vector that keeps track of distance between touch and object

    // When a touch is detected
    private void OnMouseDown()
    {
	// Enable isDragging for use in the Update function
        isDragging = true;

	// Calculate distance between touch and object. Note that transform.postion corresponds to the center of the GameObject
        offset = transform.position - GetTouchWorldPos();
    }

    // When a touch is releaesd, disable isDragging to stop tracking in theh update function
    private void OnMouseUp()
    {
        isDragging = false;
    }

    // Called every frame.
    private void Update()
    {
	// If the object is currently being dragged
        if (isDragging)
        {
	    // Generate a target position which corresponds to the current/active touch position + initial offset between the game object and starting position
            Vector3 targetPos = GetTouchWorldPos() + offset;
	    // Place the object at the new target position
            transform.position = Vector3.Lerp(transform.position, targetPos, 0.1f);
        }
    }

    // Utilize ray casting to identify the current 3D position of the touch in 3D coordinates
    private Vector3 GetTouchWorldPos()
    {
	// Convert 2D touch position (analogous to mouse position) into a ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

	// Use the ray to identify projected 3D location
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
	// If the ray does not hit anything, return the origin point.
        return Vector3.zero;
    }
}
