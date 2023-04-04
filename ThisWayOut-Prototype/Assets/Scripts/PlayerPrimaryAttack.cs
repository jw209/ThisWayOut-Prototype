using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttack : MonoBehaviour
{
    public Transform guide;
    private int cdTimer;
    public int maxCD;
    private int useTimer;
    public int maxUse;
    private bool isAttackCDActive;
    private bool isAttackUseActive;
    private int frameCount;
    public GameObject weapon;
    void Start()
    {
        frameCount = 0;
        useTimer = 0;
        cdTimer = 0;
        isAttackCDActive = false;
        isAttackUseActive = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frameCount++;
        if (Input.GetMouseButton(0) && !isAttackCDActive)
        {
            isAttackUseActive = true;
            if (frameCount % 2 != 0)
                Instantiate(weapon, guide.position, Quaternion.identity);
        }

        if (isAttackUseActive)
        {
            useTimer++;
            if (useTimer >= maxUse)
            {
                useTimer = 0;
                isAttackUseActive = false;
                isAttackCDActive = true;
            }
        }

        if (isAttackCDActive)
        {
            cdTimer++;
            if (cdTimer >= maxCD)
            {
                cdTimer = 0;
                isAttackCDActive = false;
            }
        }
    }
}
