using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // Assign your Player transform here
    public float smoothSpeed = 5f; // Camera follow smoothness
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Keeps camera behind player

    [Header("Boundary Limits (Optional)")]
    public bool useLimits = false;
    public float minX, maxX;
    public float minY, maxY;

    void LateUpdate()
    {
        if (target == null) return;

        // Desired camera position based on player position + offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move camera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Apply limits if enabled
        if (useLimits)
        {
            smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minX, maxX);
            smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minY, maxY);
        }

        transform.position = smoothedPosition;
    }
}
