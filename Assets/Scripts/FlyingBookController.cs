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
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;




    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Ensure there's a Rigidbody component attached to the book
    }

    void FixedUpdate()
    {
        HandleMovement();
        //MaintainHover();
    }

    void Update()
    {
        RotateTowardsCursor();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dodge());
        }

        if (Input.GetMouseButtonDown(0)) // Left mouse button for shooting
        {
            ShootBullet();
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
    void RotateTowardsCursor()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue); // For debugging

            // Rotate the player to face the point
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    void ShootBullet()
    {
        GameObject bullet = ObjectPoolManager.Instance.GetBullet(bulletPrefab);
        bullet.transform.position = transform.position + transform.forward; // Adjust as needed
        bullet.transform.rotation = transform.rotation;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed; // Use your bullet speed value
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

    void OnTriggerEnter(Collider other)
    {
        Page page = other.GetComponent<Page>();
        if (page != null)
        {
            // Find the PowerUpManager instance in the current level
            PowerUpManager powerUpManager = FindObjectOfType<PowerUpManager>();
            if (powerUpManager != null)
            {
                powerUpManager.CollectPage(page.pageType);
                Debug.Log("pages Collected");
            }
            Destroy(other.gameObject); // Remove the page from the scene
        }
    }

}
