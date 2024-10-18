using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;   // The player or the object to follow
    public float smoothSpeed = 0.125f;  // Speed of the camera follow smoothing
    public Vector3 offset;  // Camera offset from the target

    private void LateUpdate()
    {
        // Desired position is the target's position plus the offset
        Vector3 desiredPosition = target.position + offset;

        // Smooth the camera movement towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera's position to the smoothed position
        transform.position = smoothedPosition;
    }
}