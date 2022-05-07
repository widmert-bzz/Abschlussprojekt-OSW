using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage = 10;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "bullet")
        {
            
            Destroy(gameObject);

        }
    
        
    }






}
