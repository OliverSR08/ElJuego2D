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
    public int max_jumps = 2;
    private int avaliable_jumps = 0;
    private bool grounded = false;

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
        Debug.Log("Direction value = " + moveInput.ToString());
    }

    // Input for jump (W)
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && avaliable_jumps > 0)
        {
            avaliable_jumps -= 1;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            avaliable_jumps = max_jumps;
        }
    }

}