using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Cave : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Player")
        {
            LoadScene();
            Debug.Log("Teleporting");
        }
         
    }

    void LoadScene()
    {
        SceneManager.LoadScene(2);
    }


}
