using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    
    GameObject child;
    GameObject player;
    GameObject attackpoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private void Start()
    {

        child = GameObject.Find("Attackpoint");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
   

    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(child.transform.position, attackRange, enemyLayers);

       foreach(Collider2D enemy in hitEnemies)
       {
            Debug.Log("We hit " + enemy.name);
       }
    }


    void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;

        Gizmos.DrawWireSphere(child.transform.position, attackRange);
    }

}
