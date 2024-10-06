using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;             // Movement speed
    public float jumpForce = 7f;             // Jumping force
    public float groundCheckDistance = 1.1f; // Distance to check if the capsule is grounded
    public LayerMask groundLayer;            // Define which layer is the ground
    public float drag = 5f;                  // How quickly the character should slow down when not moving
    public Transform cameraTransform;        // Reference to the camera's transform

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;  // Ensure the capsule doesn't tip over
    }

    void Update()
    {
        Move();
        CheckGround();
        Jump();
        ApplyDrag();  // Apply drag to prevent sliding
    }

    // Handles movement
    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Get the forward direction of the camera, but ignore the vertical component (y-axis)
        Vector3 forward = cameraTransform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = cameraTransform.right;
        right.y = 0;
        right.Normalize();

        // Move the character relative to the camera's forward and right directions
        Vector3 moveDirection = (forward * moveZ + right * moveX).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            // Apply movement in the direction
            Vector3 moveVelocity = moveDirection * moveSpeed;
            rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);
        }
    }

    // Handles jumping
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Checks if the player is on the ground
    private void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }

    // Apply drag when the player is not moving to prevent sliding
    private void ApplyDrag()
    {
        // Check if no movement input is provided
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            // Apply deceleration by reducing the velocity over time
            Vector3 velocity = rb.velocity;
            velocity.x *= 1 - drag * Time.deltaTime;
            velocity.z *= 1 - drag * Time.deltaTime;
            rb.velocity = velocity;
        }
    }
}
