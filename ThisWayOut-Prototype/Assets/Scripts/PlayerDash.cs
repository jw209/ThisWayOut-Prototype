using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private int cdTimer;
    public int maxCD;
    private bool isDashCDActive;
    public float dashDistance;
    private float horzDirection;
    // Start is called before the first frame update
    void Start()
    {
        cdTimer = 0;
        isDashCDActive = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horzDirection = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.Space) && !isDashCDActive && horzDirection != 0)
        {
            isDashCDActive = true;
            transform.position = new Vector3(transform.position.x+(horzDirection*dashDistance), transform.position.y, transform.position.z);
        }

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
