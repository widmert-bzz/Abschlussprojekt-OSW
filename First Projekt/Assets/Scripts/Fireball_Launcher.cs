using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Launcher : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float fireballSpeed = 5;
    public float fireballDelay = 2;

    private float timer;


    void Start()
    {
        timer = fireballDelay;
    }

    
    void Update()
    {
        if (Input.GetButton("Fire2") && timer < 0)
        {
            Launch();
            timer = fireballDelay;
        }
            
        timer -= Time.deltaTime;
    }

    void Launch()
    {
        var fireball = Instantiate(fireballPrefab, transform.position, transform.rotation);
        var rb = fireball.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * fireballSpeed, ForceMode2D.Impulse);
    }
}
