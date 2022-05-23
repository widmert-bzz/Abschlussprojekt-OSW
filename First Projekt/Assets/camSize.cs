using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camSize : MonoBehaviour
{
    private GameObject camera1;
    private GameObject camera2;

    private void Start()
    {
        camera1 = GameObject.FindWithTag("MainCamera");
        camera2 = GameObject.FindWithTag("SecondaryCamera");
        camera2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Player")
        {
            SetCamera();
        }

    }


    public void SetCamera()
    {
        camera2.SetActive(true);
        camera1.SetActive(false);
        
    }



}
