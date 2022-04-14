using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool _isTouchingPlayer;
    public Rigidbody2D rb;
    public float speed = 2f;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void FixedUpdate()
    {

        if (_isTouchingPlayer == false)
        {
            Vector2 playerPos = (Vector2)player.transform.position - rb.position;
            rb.rotation = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg - 90f;
            rb.velocity = transform.up * speed;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            _isTouchingPlayer = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            _isTouchingPlayer = false;
        }
    }





}
