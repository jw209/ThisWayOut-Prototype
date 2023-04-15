using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPrimaryAttack : MonoBehaviour
{
    public Transform sword;
    private Vector3 endPosition;
    private Vector3 startPosition;
    private Quaternion endRotation;
    private Quaternion startRotation;
    private float desiredDuration = 0.25f;
    private float elapsedTime = 0f;
    private float percentageComplete = 0f;
    private bool attackPressed = false;
    private Controls playerControls;
    private PlayerInput playerInput;

    void Awake()
    {
        startRotation = Quaternion.Euler(0, 0, -40);
        endRotation = Quaternion.Euler(0, 0, 80);
        playerInput = GetComponent<PlayerInput>();
        playerControls = new Controls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.ControllerInput.Attack.performed += Attack;
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {   
        sword.position = transform.position;
        if (attackPressed)
        {
            startPosition = new Vector3(
                sword.position.x+0.75f,
                sword.position.y+1.25f,
                sword.position.z
            );
            endPosition = new Vector3(
                sword.position.x-0.75f,
                sword.position.y+1.0f,
                sword.position.z
            );

            elapsedTime += Time.deltaTime;
            percentageComplete = elapsedTime / desiredDuration;

            sword.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
            sword.rotation = Quaternion.Lerp(startRotation, endRotation, percentageComplete);
        }

        if (percentageComplete >= 1)
        {
            sword.position = sword.position;
            sword.rotation = startRotation;
            elapsedTime = 0f;
            percentageComplete = 0f;
            attackPressed = false;
        }
    }
    private void Attack(InputAction.CallbackContext context) 
    { 
        attackPressed = true;
    }
}
