using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    private float jumpMultiplier = 1f;
    Vector3 velocity;
    bool isGrounded;

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Calculate the jump velocity based on jump height and gravity
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity * jumpMultiplier);
            jumpMultiplier = 1f; // Reset jump multiplier after the jump
        }
    }

    void Start()
    {
        // Initial setup if necessary
    }

    void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Keep the player grounded by resetting vertical velocity
        }

        // Get input for movement along X and Z axes
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Move in the direction of the input
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Call the Jump function to handle jumping
        Jump();

        // Apply gravity to velocity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
