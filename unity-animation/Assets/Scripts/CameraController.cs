using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;         // The target to follow (the player's transform)
    public float followSpeed = 5f;  // The speed at which the camera follows the target
    public float rotationSpeed = 2f; // The speed of camera rotation
    private Vector3 offset;         // The initial offset between the camera and target
    private float rotationY = 0.0f;
    public bool isInverted;
    public float sensitivity = 2.0f;  // Assume a given sensitivity value, adjust as needed.

    private Quaternion initialRotation;  // Store the initial camera rotation.

    void Start()
    {
        // Calculate the initial offset between the camera and the target
        offset = transform.position - target.position;
        isInverted = PlayerPrefs.GetInt("isYAxisInverted", 0) == 1;
        initialRotation = transform.rotation; // Store the initial camera rotation.
    }

    void LateUpdate()
    {
        // Follow the target smoothly
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Rotate the camera based on mouse input
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.RotateAround(target.position, Vector3.up, horizontalInput);

        // Apply rotation to the camera only if the mouse is moved.
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (isInverted)
        {
            mouseY *= -1;
        }

        // Apply rotation to the camera.
        rotationY += mouseY * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -90, 90);  // Limit  vertical rotation to prevent overturning.

        // Apply the rotation to the transform of the game object.
        transform.localRotation = Quaternion.AngleAxis(-rotationY, Vector3.right);
        transform.rotation = initialRotation;  // Reset the camera's rotation to its initial state.
        transform.rotation *= Quaternion.AngleAxis(mouseX * sensitivity, transform.up);
    }

    public void ToggleInvertYAxis()
    {
        isInverted = !isInverted;
    }
}
