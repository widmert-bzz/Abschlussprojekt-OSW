using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int level;

    public Healthbar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        level = SceneManager.GetActiveScene().buildIndex;
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