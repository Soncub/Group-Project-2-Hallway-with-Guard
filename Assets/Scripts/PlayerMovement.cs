using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    // Transform of the player parent object.

    public CharacterController controller;
    // Character Controller component of the player parent object.

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    // Stuff for gravity. Ground Check object transform, distance checked for ground, and looking for the ground mask.

    public float speed = 4f;
    // Impacts forward and backward speed.

    public float rotateSpeed = 100f;
    // Impacts speed of rotation left and right.

    public float gravity = -19.62f;
    // Impacts gravity, keeps player to the ground.

    Vector3 velocity;
    // Same as above.

    bool isGrounded;
    // Boolean for gravity's ground check.

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        // Sets isGrounded to true when groundCheck is near ground based on groundDistance.

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        // Resets velocity when grounded. -2 was a good threshold to make sure it doesn't happen while you are still grounded.

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // Gets input for "Horizontal" and "Vertical" axis, which is WASD and Arrow keys. Should be configurable to include controller.

        player.Rotate(Vector3.up * x * rotateSpeed * Time.deltaTime);
        // Rotates player based on left and right input and rotation speed.

        Vector3 move = transform.forward * z;
        // Vector3 for back and forth movement.

        controller.Move(move * speed * Time.deltaTime);
        // Applies Vector3 movement value, and multiplies it by speed. Kept framerate independent with deltaTime.

        velocity.y += gravity * Time.deltaTime;
        // Changes velocity value to gradually increase as falling.

        controller.Move(velocity * Time.deltaTime);
        // Applies velocity as falling.
    }
}
