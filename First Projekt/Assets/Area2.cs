using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area2 : MonoBehaviour
{
    public ArmR rightArm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rightArm.Punch();
    }
}
