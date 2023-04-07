using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public int maxCD;
    public float dashDistance;
    private int cdTimer;
    private bool isDashCDActive;
    private float horzDirection;
    
    void Start()
    {
        cdTimer = 0;
        isDashCDActive = false;
    }

    void Update()
    {
        horzDirection = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.Space) && !isDashCDActive && horzDirection != 0)
        {
            isDashCDActive = true;
            transform.position = new Vector3(transform.position.x+(horzDirection*dashDistance), transform.position.y, transform.position.z);
        }
    }

    void FixedUpdate()
    {
        if (isDashCDActive)
        {
            cdTimer++;
            if (cdTimer >= maxCD)
            {
                cdTimer = 0;
                isDashCDActive = false;
            }
        }
    }
}
