using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    
    GameObject player;
    GameObject attackpoint;
    public float attackRange = 0.5f;
    public int damage = 10;
    public LayerMask playerLayer;
    public float attackspeed = 1f;
    float Timer;

    private void Start()
    {
        attackpoint = gameObject.transform.Find("AttackPoint").gameObject;
        Timer = attackspeed;
    }

    void Update()
    {
        Timer -= Time.deltaTime;

        DetectPlayer();
    }

    void DetectPlayer()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackpoint.transform.position, attackRange, playerLayer);

        if(hitPlayers.Length > 0)
        {
            Attack(hitPlayers[0].gameObject);
        }
    }

    void Attack(GameObject player)
    {

        if (Timer < 0)
        {
            player.GetComponent<PlayerDamage>().TakeDamage(damage);
            Timer = attackspeed;
        }
    }
        
    


    void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;

        Gizmos.DrawWireSphere(attackpoint.transform.position, attackRange);
    }

}
