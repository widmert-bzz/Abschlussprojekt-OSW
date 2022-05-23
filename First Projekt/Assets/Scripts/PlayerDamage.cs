using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public AudioClip hurtSound;
    public Healthbar healthBar;
    public GameObject Death;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.tag == "Tail")
        {
            TakeDamage(30);
        }
        else if(collisionGameObject.tag == "Claw")
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth, maxHealth);
        AudioSource.PlayClipAtPoint(hurtSound, gameObject.transform.position, 1);
        if (currentHealth < 0)
        {
            Die();
        }

    }
    void Die()
    {
        Death.SetActive(true);

    } 

}