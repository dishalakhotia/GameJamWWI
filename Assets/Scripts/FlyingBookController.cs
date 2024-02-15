using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBookController : MonoBehaviour
{
    public float speed = 10.0f; // Adjusted for more responsive movement
    public float dodgeDistance = 5.0f; // Distance for tap dodging
    public float dodgeSpeed = 0.1f; // Time it takes to complete a dodge
    private Vector3 movementVelocity; // Current velocity, for smooth damping
    public float smoothTime = 0.05f; // Smoothing time for stopping the movement
    public float hoverHeight = 2.0f; // Desired hover height
    public float hoverForce = 300f; // Force applied to maintain hover
    private Rigidbody rb; // Rigidbody component for physics-based movement

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Ensure there's a Rigidbody component attached to the book
    }

    void FixedUpdate()
    {
        HandleMovement();
        MaintainHover();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Tap space for dodging
        {
            StartCoroutine(Dodge());
        }
    }

    void HandleMovement()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 targetVelocity = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized * speed;

        // Smoothly stop the movement when keys are released
        movementVelocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref movementVelocity, smoothTime);
        rb.velocity = new Vector3(movementVelocity.x, rb.velocity.y, movementVelocity.z); // Apply horizontal movement
    }

    void MaintainHover()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            float hoverError = hoverHeight - hit.distance;
            if (hoverError > 0)
            {
                float upwardForce = hoverError * hoverForce - rb.velocity.y * rb.mass;
                rb.AddForce(Vector3.up * upwardForce);
            }
        }
    }

    System.Collections.IEnumerator Dodge()
    {
        Vector3 dodgeDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 start = transform.position;
        Vector3 end = start + dodgeDirection * dodgeDistance;

        float startTime = Time.time;
        while (Time.time < startTime + dodgeSpeed)
        {
            transform.position = Vector3.Lerp(start, end, (Time.time - startTime) / dodgeSpeed);
            yield return null;
        }
    }
}
