using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CinemachineControl : MonoBehaviour
{
    public float rotationSpeed = 3f;

    private CinemachineFreeLook freeLookCamera;
    private bool isDragging = false;
    private Vector3 lastMousePosition;

    void Start()
    {
        // Get reference to the Cinemachine FreeLook Camera component
        freeLookCamera = GetComponent<CinemachineFreeLook>();
    }

    void Update()
    {
        // Check if middle mouse button is pressed
        if (Input.GetMouseButtonDown(2))
        {
            // Start dragging
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }
        // Check if middle mouse button is released
        else if (Input.GetMouseButtonUp(2))
        {
            // Stop dragging
            isDragging = false;
        }

        // Rotate camera if dragging
        if (isDragging)
        {
            // Calculate mouse movement delta
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;

            // Rotate the camera rigs based on mouse input
            freeLookCamera.m_XAxis.m_InputAxisValue += mouseDelta.x * rotationSpeed;
            freeLookCamera.m_YAxis.m_InputAxisValue -= mouseDelta.y * rotationSpeed;

            // Store current mouse position for next frame
            lastMousePosition = Input.mousePosition;
        }
    }
}
