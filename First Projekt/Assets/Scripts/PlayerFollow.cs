using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject Player;
    public float smoothFactor = 1;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow () 
    {   
        Vector3 playerPosition = Player.transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, playerPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    } 
}
