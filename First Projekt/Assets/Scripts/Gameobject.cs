using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameobject : MonoBehaviour
{
    public Rigidbody2D door;
    public GameObject doorObject;
    public void CloseDoor()
    {
        door.velocity = new Vector2( 2, 0);
    }

    private void Update()
    {
        if (door.transform.position.x > doorObject.transform.position.x)
        {
            door.velocity = new Vector2(0, 0);
        }
    }
}
