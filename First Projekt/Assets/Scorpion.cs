using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorpion : MonoBehaviour
{
    public float tailspeed = 10;
    public float refreshTime = 10;
    public float delay = 0.5f;
    private float timer;
    public GameObject Tail;
    public Rigidbody2D Tail_rb;
    public Rigidbody2D Head_rb;
    public Rigidbody2D Body_rb;
    public Vector2 Tail_offset;
    private GameObject player;
    private bool isSwinging = false;
    private bool isReturning = false;
    private bool readyForAim = true;
    

    void Start()
    {
        player = GameObject.Find("Player");
        timer = refreshTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (isSwinging)
        {
            if(Tail.transform.position.y < 4)
            {
                Tail_rb.velocity = new Vector2(0, 5);
                isSwinging = false;
                isReturning = true;
            }
        }

        if (isReturning)
        {
            if (Tail.transform.position.y > 24)
            {
                Tail_rb.velocity = new Vector2(0, 0);
                isReturning = false;
                readyForAim = true;
                timer = refreshTime;
            }
        }
        Debug.Log(Tail.transform.position);

    }

    private void FixedUpdate()
    {

        if (readyForAim)
        {
            AimWithTail();

            //Body
            Vector2 lookDir2 = new Vector2(Tail.transform.position.x, Tail.transform.position.y) - Body_rb.position;
            float angle2 = Mathf.Atan2(lookDir2.y, lookDir2.x) * Mathf.Rad2Deg - 90f;
            Body_rb.rotation = angle2;
        }


        //Head
        Vector2 lookDir = new Vector2(player.transform.position.x, player.transform.position.y) - Head_rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        Head_rb.rotation = angle;




    }

    void AimWithTail()
    {
        if (Tail.transform.position.x < (player.transform.position.x - Tail_offset.x))
        {
            Tail_rb.velocity = new Vector2(1 * tailspeed, 0);
        }
        else if (Tail.transform.position.x > (player.transform.position.x + Tail_offset.x))
        {
            Tail_rb.velocity = new Vector2(-1 * tailspeed, 0);
        }
        else
        {
            Tail_rb.velocity = new Vector2(0, 0);
            if(timer < 0)
            {
                readyForAim = false;
                Invoke("SwingTail", delay);
            }
        }
    }

    void SwingTail()
    {
        Tail_rb.velocity = new Vector2( 0, -10);
        isSwinging = true;
    }

}
