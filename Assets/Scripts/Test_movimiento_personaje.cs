using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Collections;


public class Test_movimiento_personaje : MonoBehaviour
{
    public float speed = 1f;
    public float jump_force = 250f;
    public Rigidbody2D player;

    // Update is called once per frame
    void Update()
    {

    }

    public void Jump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Debug.Log("Se pulso la w");
            player.AddForceY(jump_force, ForceMode2D.Impulse);
        }
    }
}
