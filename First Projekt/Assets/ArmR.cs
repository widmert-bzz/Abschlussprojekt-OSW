using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArmR : MonoBehaviour
{
    public float armHitPosition = 100;
    public float armRestPosition = 35;
    public float hitDelay = 5;
    public Rigidbody2D rb;
    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime; 
    }
    public void Punch()
    {
        if(timer < 0)
        {
            rb.rotation = armHitPosition;
        } 
    }
}
