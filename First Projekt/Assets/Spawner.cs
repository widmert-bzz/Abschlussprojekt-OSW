using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject Enemyprefab;
    private float timer = 0f;
    public float mineCooldown = 10f;


    private void Start()
    {
        timer = mineCooldown;


    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Shoot();
            timer = mineCooldown;

        }
    }



    void Shoot()
    {
        GameObject Enemy = Instantiate(Enemyprefab);
    }
}
