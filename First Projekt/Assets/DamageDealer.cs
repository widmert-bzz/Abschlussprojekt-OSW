using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    public Transform attackPoint;
    GameObject player;
    public float attackDistance;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private void Start()
    {
         player = GameObject.Find("Player");
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);


        if (distance > attackDistance)
        {
            Attack();
        }

    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

       foreach(Collider2D enemy in hitEnemies)
       {
            Debug.Log("We hit" + enemy.name);
       }
    }

}
