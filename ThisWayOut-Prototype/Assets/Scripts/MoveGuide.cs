using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveGuide : MonoBehaviour
{
    public Transform pivot;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Controls playerControls;
    private PlayerInput playerInput;

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
        movement = playerControls.ControllerInput.Cast.ReadValue<Vector2>();
    }

    void HandleMovement() 
    {
        transform.position = new Vector3(pivot.position.x + movement.x, pivot.position.y + movement.y, transform.position.z);

    }
}
