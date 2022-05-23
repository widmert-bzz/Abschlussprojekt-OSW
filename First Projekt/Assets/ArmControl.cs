using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmControl : MonoBehaviour
{
    public float hitDelay = 5f;
    public float armSpeed = 20f;
    public Rigidbody2D rbR;
    public Rigidbody2D rbL;
    public AudioClip punch;
    private float timerR = 0;
    private float timerL = 0;
    private ArmStateR armStateR = ArmStateR.RestingR;
    private ArmStateL armStateL = ArmStateL.RestingL;

    private void Start()
    {
        timerR = hitDelay;
        timerL = hitDelay;
    }
    private void Update()
    {
        timerR -= Time.deltaTime;
        timerL -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (armStateR == ArmStateR.PunchingR)
        {
            if (rbR.rotation > -95)
            {
                rbR.rotation -= armSpeed * Time.deltaTime;
            }
            else
            {
                armStateR = ArmStateR.ReturningR;
            }
        }

        if (armStateR == ArmStateR.ReturningR)
        {
            if (rbR.rotation < -35)
            {
                rbR.rotation += armSpeed * Time.deltaTime;
            }
            else
            {
                armStateR = ArmStateR.RestingR;
                timerR = hitDelay;
            }
        }

        if (armStateL == ArmStateL.PunchingL)
        {
            if (rbL.rotation < 95)
            {
                rbL.rotation += armSpeed * Time.deltaTime;
            }
            else
            {
                armStateL = ArmStateL.ReturningL;
            }
        }

        if (armStateL == ArmStateL.ReturningL)
        {
            if (rbL.rotation > 35)
            {
                rbL.rotation -= armSpeed * Time.deltaTime;
            }
            else
            {
                armStateL = ArmStateL.RestingL;
                timerL = hitDelay;
            }
        }
    }
    public void PunchR()
    {
        if (timerR < 0 && armStateR != ArmStateR.ReturningR && armStateL != ArmStateL.PunchingL)
        {
            armStateR = ArmStateR.PunchingR;
           
        }
        

    }
    public void PunchL()
    {
        if (timerL < 0 && armStateL != ArmStateL.ReturningL && armStateR != ArmStateR.PunchingR)
        {
            armStateL = ArmStateL.PunchingL;
         
        }
        
    }

    public void PunchdelayR()
    {
        Invoke("PunchR", 2);
    }

    public void PunchdelayL()
    {
        Invoke("PunchL", 2);
    }
    enum ArmStateR
    {
        PunchingR,
        ReturningR,
        RestingR
    }
    enum ArmStateL
    {
        PunchingL,
        ReturningL,
        RestingL
    }
}
