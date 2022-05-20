using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage = 10;
    public ParticleSystem destroyParticles;
    public GameObject spawn;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "bullet")
        {
            delete();

        }      
    }

    void delete()
    {
        Instantiate(destroyParticles, spawn.transform.position, transform.rotation);
        Destroy(gameObject);
    }




}
