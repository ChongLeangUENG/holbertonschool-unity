using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;         // The target to follow (the player's transform)
    public float followSpeed = 5f;  // The speed at which the camera follows the target
    public float rotationSpeed = 2f; // The speed of camera rotation
    private Vector3 offset;         // The initial offset between the camera and target

    void Start()
    {
        // Calculate the initial offset between the camera and the target
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Follow the target smoothly
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Rotate the camera based on mouse input
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.RotateAround(target.position, Vector3.up, horizontalInput);
    }
}
