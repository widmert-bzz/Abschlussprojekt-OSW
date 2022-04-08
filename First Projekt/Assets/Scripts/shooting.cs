using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public Text munitionCount;

    public float ReloadTime = 3f;
    public float MagSize = 25f;
    public float bulletForce = 20f;
    public float bulletDelay = 1f;
    private float timer = 0.1f;
    private float timerR = 0f;
    private float counter = 0f;
    private float counter2 = 2f;
    

    private void Start()
    {
        timer = bulletDelay;
        timerR = 0;
        counter = MagSize;


    }
    void Update()
    {
        timer -= Time.deltaTime;
        timerR -= Time.deltaTime;

        if(timerR < 0)
        {
            if (counter2 == 1)
            {
                counter = MagSize;
            }
        }



        if (Input.GetButton("Fire1") && timer < 0 && timerR < 0)
        {
            counter2++;


            if(counter > 0)
            {
                Shoot();
                counter--;
                timer = bulletDelay;
            }
            else
            {
                timerR = ReloadTime;
                counter2 = 0;

            }





        }


        munitionCount.text = (counter) + "/" + (MagSize);

    }



    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

}
