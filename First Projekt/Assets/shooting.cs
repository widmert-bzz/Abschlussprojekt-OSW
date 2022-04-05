using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float ReloadTime = 3f;
    public float MagSize = 25f;
    public float bulletForce = 20f;
    public float bulletDelay = 1f;
    private float timer = 0.1f;
    private float timerR = 0f;
    private float counter = 0;
    

    private void Start()
    {
        timer = bulletDelay;
        timerR = 0;


    }
    void Update()
    {
        timer -= Time.deltaTime;
        timerR -= Time.deltaTime;

        
        if (Input.GetButton("Fire1") && timer < 0 && timerR < 0)
        {
            if(counter <= MagSize)
            {
                Shoot();
                counter++;
            }
            else
            {
                timerR = ReloadTime;
                counter = 0;
            }
            
            
            timer = bulletDelay;

        }
    }



    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

}
