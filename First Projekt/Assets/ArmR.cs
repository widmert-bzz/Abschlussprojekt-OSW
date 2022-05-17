using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArmR : MonoBehaviour
{
    public float armHitPosition = -100;
    public float armRestPosition = 35;
    public float hitDelay = 5;
    public Rigidbody2D rb;
    private float timer;
    private ArmState armState = ArmState.Resting;

    private void Update()
    {
        timer -= Time.deltaTime;

        
    }

    private void FixedUpdate()
    {
        if (armState == ArmState.Punching)
        {
            rb.rotation = Mathf.Lerp(rb.rotation, armRestPosition, Time.deltaTime * timer);
        }
    }
    public void Punch()
    {
        if(timer < 0)
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
