using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area2 : MonoBehaviour
{
    public ArmR rightArm;

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;
        if (player.name == "Player")
        {
            rightArm.Punchdelay();
        } 
    }
}
