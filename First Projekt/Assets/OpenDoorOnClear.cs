using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorOnClear : MonoBehaviour
{
    public List<GameObject> enemys = new List<GameObject>();
    public Rigidbody2D rb;
    public Transform trans;
    private void Update()
    {
        if (enemys.Count == 0)
        {
            rb.velocity = new Vector3(2,0,0);
        }

        if (rb.position.x > trans.position.x)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
