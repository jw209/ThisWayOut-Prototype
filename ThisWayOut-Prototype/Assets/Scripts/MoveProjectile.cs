using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private float angle;
    private Vector3 direction;
    private Vector3 mousePos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = GameObject.FindWithTag("Guide").transform.position - mousePos;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.up*speed);
        Destroy(this.gameObject, 5);
    }
}
