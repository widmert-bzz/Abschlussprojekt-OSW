using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArmL : MonoBehaviour
{
    public float armHitPosition = 100;
    public float armRestPosition = 35;
    public float hitDelay = 5f;
    public float armSpeed = 5f;
    public Rigidbody2D rb;
    private float timer;
    private ArmState armState = ArmState.Resting;

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    private void FixUpdate()
    {
        if (armState == ArmState.Punching)
        {
            if( rb.rotation < 100)
            {
                rb.rotation = armSpeed * Time.deltaTime;
            }
           
        }
    }
    public void Punch()
    {
        if (timer < 0)
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
