using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float health = 20;
    public GameObject munitionBundle;
    public ParticleSystem bloodParticles;
    private GameObject door;
    OpenDoorOnClear doorvar;

    private void Start()
    {
        door = GameObject.Find("DoorExit");
        doorvar = door.GetComponent<OpenDoorOnClear>();
        doorvar.enemys.Add(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            CreateParticles();
            health -= 10;
            if (health <= 0)
            {
                delete();
            }
        }
    }

    void CreateParticles()
    {
        Instantiate(bloodParticles, transform.position, Quaternion.identity);
    }

    void delete()
    {
        doorvar.enemys.Remove(gameObject);
        if (Random.value <= 0.1)
        {
            Instantiate(munitionBundle, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
