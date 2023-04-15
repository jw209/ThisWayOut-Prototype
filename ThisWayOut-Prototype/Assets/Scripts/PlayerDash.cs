using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance;
    public float CooldownDuration;
    private Controls playerControls;
    private PlayerInput playerInput;
    private bool isDashAvailable;
    void Awake()
    {
        isDashAvailable = true;
        playerControls = new Controls();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.ControllerInput.Dash.performed += Dash;
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Dash(InputAction.CallbackContext context) 
    {
        float _horzDirection = Input.GetAxisRaw("Horizontal");
        if (isDashAvailable && _horzDirection != 0f) {
            transform.position = new Vector3(transform.position.x+(_horzDirection*dashDistance), transform.position.y, transform.position.z);
            StartCoroutine(StartCooldown());
        }
    }

    public IEnumerator StartCooldown()
    {
        isDashAvailable = false;
        yield return new WaitForSeconds(CooldownDuration);
        isDashAvailable = true;
    }
}
