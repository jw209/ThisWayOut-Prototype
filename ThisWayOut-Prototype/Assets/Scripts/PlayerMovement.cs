using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Controls playerControls;
    private PlayerInput playerInput;
    private Vector2 movement;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new Controls();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void FixedUpdate()
    {
        HandleInput();
        HandleMovement();
    }

    void HandleInput()
    {
        movement = playerControls.ControllerInput.Move.ReadValue<Vector2>();
    }

    void HandleMovement() 
    {
        rb.velocity = movement * speed;
    }

}
