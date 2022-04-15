using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Healthbar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
    }
   

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth, maxHealth);

        if (currentHealth < maxHealth)
        {
            Die();
        }


    }
    void Die()
    {
        Debug.Log("Player died!");
    } 
            
        





}