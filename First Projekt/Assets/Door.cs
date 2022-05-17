using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Rigidbody2D door;
    public void CloseDoor()
    {
        door.velocity = new Vector2( 3, 0);
    }

    private void Update()
    {
        if (door.transform.position.x > 0)
        {
            door.velocity = new Vector2(0, 0);
        }
    }
}
