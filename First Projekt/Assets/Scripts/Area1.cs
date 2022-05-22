using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area1 : MonoBehaviour
{
    public ArmControl armControl;

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;
        if (player.name == "Player")
        {
            armControl.PunchdelayL();
        }
    }
}
