using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool _isTouchingPlayer;
    public Rigidbody2D rb;
    public float speedinput = 2f;
    private float speed;
    private GameObject player;
    public Collider2D collider2d;
    public ContactFilter2D contactFilter;
    public float pushForce;
    Vector3 directions;
    Vector3 enemyToOtherEnemys;
    private GameObject door;


    private void Start()
    {
        player = GameObject.Find("Player");
        speed = speedinput;

        contactFilter.useLayerMask = true;

    }
    private void FixedUpdate()
    {
        if ( 20 < Vector3.Distance(transform.position, player.transform.position))
        {
            speed = 0;
        }
        else
        {
            speed = speedinput;
        }


        List<Collider2D> result = new();
        collider2d.OverlapCollider(contactFilter, result);

        _isTouchingPlayer = false;


        if (result.Count > 0)
        {
            directions = Vector3.zero;


            foreach (var collider in result)
            {
                Vector3 direction = (collider.gameObject.transform.position - transform.position).normalized;
                float weight = 0.88f - Vector3.Distance(collider.gameObject.transform.position, transform.position);


                if (collider.gameObject.CompareTag("Player"))
                {
                    _isTouchingPlayer = true;
                }

                directions += direction * weight;

            }

            directions /= result.Count;
            
        }
        else
        {
            directions = Vector3.zero;
        }

        Vector2 playerPos = (Vector2)player.transform.position - rb.position;

        if (!_isTouchingPlayer)
        {
            rb.rotation = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg - 90f;
            rb.velocity = (transform.up * speed) - (directions * pushForce);
        }
        else
        {
            rb.velocity = Vector2.zero - (Vector2)(directions * pushForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position - directions);
    }


}
