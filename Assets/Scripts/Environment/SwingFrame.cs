using UnityEngine;

public class SwingFrame : MonoBehaviour
{
    public float swingAngle = 30f;       // Maximum swing angle in degrees
    public float swingSpeed = 2f;        // Speed of swinging
    public float swingDuration = 2f;     // Duration for swinging (in seconds)
    private float swingTime = 0f;        // Time tracker for swinging
    private bool isSwinging = true;      // Controls swinging
    private Quaternion initialRotation;  // Starting rotation of the frame
    private Rigidbody rb;                // Rigidbody for the frame

    void Start()
    {
        initialRotation = transform.rotation; // Store the initial rotation
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Disable physics while swinging
    }

    void Update()
    {
        if (isSwinging)
        {
            SwingingFrame(); // Handle the swinging
        }
    }

    private void SwingingFrame()
    {
        
        // Increment time
        swingTime += Time.deltaTime;

        // Drop the frame after swingDuration seconds
        if (swingTime >= swingDuration)
        {
            isSwinging = false; // Stop swinging
            DropFrame(); // Drop the frame after 4 seconds
        }
    }

    private void DropFrame()
    {
        rb.isKinematic = false; // Enable physics
        rb.useGravity = true;   // Allow gravity to take effect
    }
}
