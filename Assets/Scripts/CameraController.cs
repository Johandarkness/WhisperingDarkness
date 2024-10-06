using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerBody;        // Reference to the player's body
    public float mouseSensitivity = 100f;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   // Lock the cursor to the center of the screen
    }

    void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the camera vertically
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);   // Clamp vertical rotation so the camera doesn't flip

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player horizontally
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
