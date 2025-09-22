using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_movimiento_personaje : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    private float moveInput;

    [Header("Jump")]
    public float jumpForce = 7f;

    [Header("Components")]
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        // Horizontal movement
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    // Input for horizontal movement (A/D)
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<float>();
    }

    // Input for jump (W)
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump!");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}