using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionTail : MonoBehaviour
{
    public Scorpion scorpion;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        scorpion.ReturnTail();
    }
}
