using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    private Rigidbody rb;
    private bool isGrounded;
    public Vector3 startPosition; // Store the starting position

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position; // Store the starting position
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // Handle player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Handle jumping with Spacebar
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Check if player has fallen below a certain Y-position
        if (transform.position.y < -10f) // Adjust this value as needed
        {
            // Respawn the player at the starting position
            Respawn();
        }
    }

    private void Respawn()
    {
        // Reset the player's position to the starting position
        transform.position = startPosition;
        rb.velocity = Vector3.zero; // Reset the player's velocity
    }
}
