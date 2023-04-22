using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spellcaster : MonoBehaviour
{
    public float maxTimeAllowed;
    public float CooldownDuration;
    public Transform player;
    public GameObject[] spellBindings;
    public GameObject[] spellElements;
    private GameObject currentSpell;
    private int timer;
    private int conditionsMet;
    private int frame;
    private int selection;
    private int maxSelections;
    private bool timerActive;
    private bool castActive;
    private bool castTimerActive;
    private bool nullifyCast;
    private bool changeSelection;
    private Controls playerControls;
    private PlayerInput playerInput;

    private Vector2 castEntryUpperBound;
    private Vector2 castEntryLowerBound;
    private Vector2 castExit;

    void Awake()
    {
        playerControls = new Controls();
        playerInput = GetComponent<PlayerInput>();

        maxSelections = spellBindings.Length;
        changeSelection = false;
        selection = 0;
        conditionsMet = 0;
        timerActive = false;
        castActive = false;
        nullifyCast = false;
        frame = 0;

        // Set default spell caster
        currentSpell = Instantiate(spellBindings[selection], player.position, Quaternion.identity);
        currentSpell.transform.parent = player;
    }

    void Update()
    {   
        if (changeSelection)
        {
            if (currentSpell != null) Destroy(currentSpell);
            currentSpell = Instantiate(spellBindings[selection], player.position, Quaternion.identity);
            currentSpell.transform.parent = player;
            changeSelection = false;
        }

        // Check if all conditions are met
        if (conditionsMet == 3 && castTimerActive)
        {

            Debug.Log("should cast");
            castActive = true;

            // Either way, reset conditions
            conditionsMet = 0;
            timer = 0;
        }
        //Vector2 xy = playerControls.ControllerInput.Cast.ReadValue<Vector2>();
        //Debug.Log(xy.x + " " + xy.y);

    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.ControllerInput.SwitchSpell.performed += Switch;
    }

    void FixedUpdate()
    {
        // Increment the timer each frame if in sequence
        if (timerActive) timer++;

        // If cast was successful trigger spell
        if (castActive)
        {
            switch (selection)
            {
                case 0:
                    CastFrostSpell(frame);
                    break;
                case 1:
                    CastFireSpell(frame);
                    break;
                default:
                    break;
            }
            frame += 10;
            if (frame >= 360)
            {
                frame = 0;
                castActive = false;
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "errorpoint") 
        {
            StartCoroutine(StartCooldown());
        }

        if (col.gameObject.name == "hitpointA" && conditionsMet == 0 && !nullifyCast && !castTimerActive) 
        {
            StartCoroutine(TimeCast());
            conditionsMet++;
        }
        else if (col.gameObject.name == "hitpointB" && conditionsMet == 1 && !nullifyCast) 
        {
            conditionsMet++;
        }
        else if (col.gameObject.name == "hitpointC" && conditionsMet == 2 && !nullifyCast) 
        {
            conditionsMet++;
        }
    }

    void CastFrostSpell(int frame)
    {
        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(0, 0, frame);
        Instantiate(spellElements[selection], player.position, rotation);
    }

    void CastFireSpell(int frame)
    {
        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(0, 0, frame*Mathf.Sin(frame));
        Instantiate(spellElements[selection], player.position, rotation);
    }

    private void Switch(InputAction.CallbackContext context)
    {
        selection++;
        if (selection == maxSelections) selection = 0;
        changeSelection = true;
    }

    public IEnumerator StartCooldown()
    {
        nullifyCast = true;
        yield return new WaitForSeconds(CooldownDuration);
        nullifyCast = false;
    }
    
    public IEnumerator TimeCast()
    {
        castTimerActive = true;
        yield return new WaitForSeconds(maxTimeAllowed);
        castTimerActive = false;
    }
}
