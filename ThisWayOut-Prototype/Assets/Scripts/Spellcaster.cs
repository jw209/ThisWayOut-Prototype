using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellcaster : MonoBehaviour
{
    public int maxTimeAllowed;
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

    void Start()
    {
        maxSelections = spellBindings.Length;
        selection = 0;
        conditionsMet = 0;
        timerActive = false;
        castActive = false;
        frame = 0;

        // Set default spell caster
        currentSpell = Instantiate(spellBindings[selection], player.position, Quaternion.identity);
        currentSpell.transform.parent = player;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            selection++;
            if (selection == maxSelections) selection = 0;

            if (currentSpell != null) Destroy(currentSpell);
            currentSpell = Instantiate(spellBindings[selection], player.position, Quaternion.identity);
            currentSpell.transform.parent = player;
        }
    }

    void FixedUpdate()
    {
        // Increment the timer each frame if in sequence
        if (timerActive) timer++;

        // Check if all conditions are met
        if (conditionsMet == 4)
        {
            // Sequence completed fast enough
            if (timer <= maxTimeAllowed) castActive = true;

            // Either way, reset conditions
            conditionsMet = 0;
            timer = 0;
        }

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

        // If timer exceeds time limit, reset variables
        if (timer >= maxTimeAllowed) 
        {
            conditionsMet = 0;
            timer = 0;
            timerActive = false;
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "PointA" && conditionsMet == 0) 
        {
            timerActive = true;
            conditionsMet++;
        }
        else if (col.gameObject.name == "PointB" && conditionsMet == 1) 
        {
            conditionsMet++;
        }
        else if (col.gameObject.name == "PointC" && conditionsMet == 2) 
        {
            conditionsMet++;
        }
        else if (col.gameObject.name == "PointA" && conditionsMet == 3) 
        {
            timerActive = false;
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
}
