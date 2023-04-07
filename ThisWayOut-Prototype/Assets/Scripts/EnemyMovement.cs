using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private Vector3 direction;
    private float step = 0.0001f;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (target.position != transform.position)
        {
            direction = target.position - transform.position;
            direction *= step;
            transform.position = new Vector3(
                transform.position.x+direction.x,
                transform.position.y+direction.y,
                transform.position.z
            );
        }
    }
}
