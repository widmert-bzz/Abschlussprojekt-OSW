using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{

    public Image fill;


    public void SetHealth(int health, int maxHealth)
    {
        fill.fillAmount = 1f / maxHealth * health;

    }

}
