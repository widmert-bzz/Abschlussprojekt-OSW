using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    public float bulletDelay = 1f;
    private float timer = 0f;

    private void Start()
    {
        timer = bulletDelay;




    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && timer < 0 )
        {
            Shoot();
            
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
