using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float speed;
    public float destroyTimer;
    private Rigidbody2D rb;
    private float angle;
    private Vector3 direction;
    private Vector3 mousePos;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = GameObject.FindWithTag("Guide").transform.position - mousePos;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
    }

    void Update()
    {
        rb.AddForce(transform.up*speed);
        Destroy(this.gameObject, destroyTimer);
    }
}
