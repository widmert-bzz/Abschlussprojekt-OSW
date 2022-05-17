using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area1 : MonoBehaviour
{
    public ArmL leftArm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        leftArm.Punch();
    }


}
