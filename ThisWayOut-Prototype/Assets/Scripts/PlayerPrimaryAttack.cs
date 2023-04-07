using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttack : MonoBehaviour
{
    public Transform sword;
    public Transform player;
    private Vector3 endPosition;
    private Vector3 startPosition;
    private Quaternion endRotation;
    private Quaternion startRotation;
    private float desiredDuration = 0.25f;
    private float elapsedTime = 0f;
    private float percentageComplete = 0f;
    private bool attack = false;

    void Start()
    {
        startRotation = Quaternion.Euler(0, 0, -40);
        endRotation = Quaternion.Euler(0, 0, 80);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) attack = true;

        if (attack)
        {
            startPosition = new Vector3(
                player.position.x+0.75f,
                player.position.y+1.25f,
                player.position.z
            );
            endPosition = new Vector3(
                player.position.x-0.75f,
                player.position.y+1.0f,
                player.position.z
            );

            elapsedTime += Time.deltaTime;
            percentageComplete = elapsedTime / desiredDuration;

            transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, percentageComplete);
        }

        if (percentageComplete >= 1)
        {
            transform.position = player.position;
            transform.rotation = startRotation;
            elapsedTime = 0f;
            percentageComplete = 0f;
            attack = false;
        }
    }
}
