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
    private float shootDelay = 0.1f;
    private float reloadTimer = 0f;
    private float remainingBullets = 0f;
    private float counter2 = 2f;
    

    private void Start()
    {
        shootDelay = bulletDelay;
        reloadTimer = 0;
        remainingBullets = MagSize;


    }
    void Update()
    {
        shootDelay -= Time.deltaTime;
        reloadTimer -= Time.deltaTime;

        if(reloadTimer < 0)
        {
           
        }


        if (Input.GetButton("Fire1") && shootDelay < 0 && reloadTimer < 0)
        {
            counter2++;

            if(remainingBullets > 0)
            {
                Shoot();
                remainingBullets--;
                shootDelay = bulletDelay;
            }
            else
            {
                reloadTimer = ReloadTime;
                counter2 = 0;
            }
        }

        munitionCount.text = (remainingBullets) + "/" + (MagSize);

    }



    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

}
