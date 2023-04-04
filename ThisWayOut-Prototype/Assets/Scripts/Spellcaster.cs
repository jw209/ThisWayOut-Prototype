using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellcaster : MonoBehaviour
{
    private bool pointA;
    private bool pointB;
    private bool pointC;
    private bool sequenceStart;
    // Start is called before the first frame update
    void Start()
    {
        pointA = false;
        pointB = false;
        pointC = false;
        sequenceStart = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "PointA" && sequenceStart)
        {
            pointA = true;
            sequenceStart = false;
        }
        else if (col.gameObject.name == "PointB" && !sequenceStart && pointA)
        {
            pointB = true;
        }
        else if (col.gameObject.name == "PointC" && !sequenceStart && pointA && pointB)
        {
            pointC = true;
        }
        else if (col.gameObject.name == "PointA" && !sequenceStart && pointA && pointB && pointC)
        {
            Debug.Log("Cast!");
            pointA = false;
            pointB = false;
            pointC = false;
            sequenceStart = true;
        }
    }
}
