using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArmR : MonoBehaviour
{
    public float armHitPosition = 100;
    public float armRestPosition = 35;
    public float hitDelay = 5f;
    public float armSpeed = 20f;
    public Rigidbody2D rb;
    private float timer = 0;
    private ArmState armState = ArmState.Resting;

    private void Start()
    {
        timer = hitDelay;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (armState == ArmState.Punching)
        {
            if (rb.rotation > -95)
            {
                rb.rotation -= armSpeed * Time.deltaTime;
            }
            else
            {
                armState = ArmState.Returning;
            }
        }

        if (armState == ArmState.Returning)
        {
            if (rb.rotation < -35)
            {
                rb.rotation += armSpeed * Time.deltaTime;
            }
            else
            {
                armState = ArmState.Resting;
                timer = hitDelay;
            }
        }
    }
    public void Punch()
    {
        if (timer < 0 && armState != ArmState.Returning)
        {
            armState = ArmState.Punching;
        }
    }
    enum ArmState
    {
        Punching,
        Returning,
        Resting
    }
}
