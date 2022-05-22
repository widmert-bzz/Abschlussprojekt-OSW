using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int health;
    public int munition;
    public int munitionMag;
    public int scene;
    public float[] position;
    

    public PlayerData (Shooting shooting, PlayerDamage damage)
    {
        munitionMag = shooting._remainingBullets;
        munition = shooting.ammoRemaining;
        health = damage.currentHealth;
        scene = damage.level;

        position = new float[3];
        position[0] = damage.transform.position.x;
        position[1] = damage.transform.position.y;
        position[2] = damage.transform.position.z;
    }
}
