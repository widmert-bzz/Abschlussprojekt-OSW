using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float bulletDamage = 10;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "bullet")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);

        }
    
        
    }






}
