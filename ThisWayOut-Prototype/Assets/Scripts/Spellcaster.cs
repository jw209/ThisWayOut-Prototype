using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spellcaster : MonoBehaviour
{
    public int maxTimeAllowed;
    public Transform player;
    private bool pointA;
    private bool pointB;
    private bool pointC;
    private bool sequenceStart;
    private int timer;
    private bool startTimer;
    private bool castComplete;
    private bool castBegin;
    private int frame;

    public virtual void Start()
    {
        pointA = false;
        pointB = false;
        pointC = false;
        sequenceStart = false;
        startTimer = false;
        castComplete = false;
        castBegin = false;
        frame = 0;
    }

    public virtual void FixedUpdate()
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
                castBegin = true;
            }
            else if (timer > maxTimeAllowed)
            {
                Debug.Log("Unsuccesful cast");
            }
            castComplete = false;
            timer = 0;
        }

        if (castBegin)
        {
            CastSpell(frame);
            frame += 10;
            if (frame >= 360)
            {
                frame = 0;
                castBegin = false;
            }
        }
    }
    
    public virtual void OnTriggerEnter2D(Collider2D col)
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
            pointA = false;
            pointB = false;
            pointC = false;
            sequenceStart = false;
            startTimer = false;
            castComplete = true;
        }
    }

    public virtual void CastSpell(int frame) {   }
}
