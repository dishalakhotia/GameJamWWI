using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotator : MonoBehaviour
{
    public float sensitivity = 100f; // Control how sensitive the rotation is to mouse movement

    void Update()
    {
        // Get horizontal mouse movement
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        // Apply the rotation around the y-axis
        transform.Rotate(Vector3.up * mouseX);
    }
}