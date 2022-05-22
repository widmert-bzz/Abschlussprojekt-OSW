using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerspawn : MonoBehaviour
{
    private GameObject player;
    private GameObject cam;
    void Start()
    {
        player = GameObject.Find("Player");
        cam = GameObject.Find("MainCamera");
        player.transform.position = transform.position;
        cam.transform.position = transform.position;
    }
}
