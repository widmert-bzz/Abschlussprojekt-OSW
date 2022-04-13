using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform position;
    public GameObject Enemyprefab;
    private float timer = 0f;
    public float cooldown = 10f;


    private void Start()
    {
        timer = cooldown;


    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Spawn();
            timer = cooldown;

        }
    }



    void Spawn()
    {
        Instantiate(Enemyprefab);
    }
}
