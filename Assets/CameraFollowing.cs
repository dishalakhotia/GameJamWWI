using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform target; // Target to follow (e.g., player)
    public float followSpeed = 5f; // Speed of following
    public float zoomSpeed = 2f; // Speed of zooming
    public float rotationSpeed = 5f; // Speed of rotation
    public Vector3 offset = new Vector3(0, 10, -10); // Camera offset from target

    void Update()
    {
        // Follow the target smoothly
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        }

        // Zoom in/out with the mouse scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        offset += transform.forward * scroll * zoomSpeed;

        // Rotate the camera around the target with right mouse button
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            Vector3 rotation = new Vector3(-mouseY, mouseX, 0) * rotationSpeed;
            transform.RotateAround(target.position, Vector3.up, rotation.x);
            transform.RotateAround(target.position, transform.right, rotation.y);
        }

        // Reset camera rotation with middle mouse button
        if (Input.GetMouseButton(2))
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
