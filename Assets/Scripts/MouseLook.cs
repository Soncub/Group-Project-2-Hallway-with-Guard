using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 1000f;
    // Sensitivity for Mouselook. Default is 1000. Scale should likely be 100-2000.

    float xRotation = 0f;
    float yRotation = 0f;
    // Rotation variable for looking up and down.

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Locks mouse when in game. Will need to make sure that mouse is unlocked for menus.
    }

    void Update()
    {
        float mouseY = (Input.GetAxis("Mouse Y")) * mouseSensitivity * Time.deltaTime;
        // Gets input for Y axis. Unity should be able to configure this for Joysticks. Kept framerate independent with deltaTime.

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 45f);
        // Setting the rotation variable to the right value.

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        // Gets input for Y axis. Unity should be able to configure this for Joysticks. Kept framerate independent with deltaTime.

        yRotation -= -mouseX;
        yRotation = Mathf.Clamp(yRotation, -45f, 45f);
        // Setting the rotation variable to the right value.

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        // Applying the rotation variable value to the actual camera.
        
    }
}
