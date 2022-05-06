using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float walkingDuration;
    public float speed;
    public float volume;
    public Rigidbody2D rb;
    public Camera cam;
    public AudioClip walkingSound;
    Vector2 mousePos;
    private Vector2 moveDirection;
    private float moveX = 0f;
    private float moveY = 0f;
    private float timer;

    void Update()
    {
        ProcessInputs();

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (timer < 0 && (moveX != 0 || moveY != 0))
        {
            AudioSource.PlayClipAtPoint(walkingSound, gameObject.transform.position, volume);
            timer = walkingDuration;
        }
        timer -= Time.deltaTime;
    }

    void ProcessInputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        Move();
    }
}
