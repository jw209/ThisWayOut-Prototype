using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellcaster : MonoBehaviour
{
    public int maxTimeAllowed;
    private bool pointA;
    private bool pointB;
    private bool pointC;
    private bool sequenceStart;
    private int timer;
    private bool startTimer;
    private bool castComplete;

    void Start()
    {
        pointA = false;
        pointB = false;
        pointC = false;
        sequenceStart = false;
        startTimer = false;
        castComplete = false;
    }

    void FixedUpdate()
    {
        if(startTimer) 
        {
            timer++;
        }

        if (castComplete)
        {
            if (timer <= maxTimeAllowed)
            {
                Debug.Log("Successful cast");
            }
            else if (timer > maxTimeAllowed)
            {
                Debug.Log("Unsuccesful cast");
            }
            castComplete = false;
            timer = 0;
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "PointA" && !sequenceStart)
        {
            pointA = true;
            sequenceStart = true;
            startTimer = true;
        }
        else if (col.gameObject.name == "PointB" && sequenceStart && pointA)
        {
            pointB = true;
        }
        else if (col.gameObject.name == "PointC" && sequenceStart && pointA && pointB)
        {
            pointC = true;
        }
        else if (col.gameObject.name == "PointA" && sequenceStart && pointA && pointB && pointC)
        {
            castComplete = true;
            pointA = false;
            pointB = false;
            pointC = false;
            sequenceStart = false;
            startTimer = false;
        }
    }
}
