using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttack : MonoBehaviour
{
    public Transform guide;
    public GameObject weapon;
    public int maxCD;
    public int maxUse;
    private int cdTimer;
    private int useTimer;
    private bool isAttackCDActive;
    private bool isAttackUseActive;
    private int frameCount;

    void Start()
    {
        frameCount = 0;
        useTimer = 0;
        cdTimer = 0;
        isAttackCDActive = false;
        isAttackUseActive = false;
    }

    void FixedUpdate()
    {
        frameCount++;
        if (Input.GetMouseButton(0) && !isAttackCDActive)
        {
            isAttackUseActive = true;
            if (frameCount % 2 != 0)
            {
                Instantiate(weapon, guide.position, Quaternion.identity);
            }
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
