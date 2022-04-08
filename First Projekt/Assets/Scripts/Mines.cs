using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : MonoBehaviour
{
    public Transform MinePoint;
    public GameObject minePrefab;
    private float timer = 0f;
    public float mineCooldown = 10f;


    private void Start()
    {
        timer = mineCooldown;


    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetButton("Fire2") && timer < 0)
        {
            Shoot();
            timer = mineCooldown;

        }
    }



    void Shoot()
    {
        GameObject mine = Instantiate(minePrefab, MinePoint.position, MinePoint.rotation);
        Rigidbody2D rb = mine.GetComponent<Rigidbody2D>();
    }
}
