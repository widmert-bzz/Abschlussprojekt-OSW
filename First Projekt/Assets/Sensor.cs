using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public Door door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject triggerObject = collision.gameObject;
        if (triggerObject.name == "Player")
        {
            door.CloseDoor();
        }
        
    }
}
