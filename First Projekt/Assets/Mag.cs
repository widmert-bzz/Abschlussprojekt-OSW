using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Player")
        {
            Shooting shooting = (Shooting)collisionGameObject.GetComponent<Shooting>();
            shooting.AddAmmo();
            Destroy(gameObject);
        }
    }
}
