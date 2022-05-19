using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionTail : MonoBehaviour
{
    public Scorpion scorpion;
    public ParticleSystem poison;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        scorpion.ReturnTail();
        poison.Play();
        GameObject hitObject = collision.gameObject;
        if (hitObject.name == "Core")
        {
            scorpion.TakeCoreDamage();
        }
    }
    

}
