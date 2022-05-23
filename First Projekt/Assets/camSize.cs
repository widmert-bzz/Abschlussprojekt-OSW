using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camSize : MonoBehaviour
{
    private Camera _camera;
    private bool _isGettingBigger = false;
    private float _time = 0;

    [Range(0, 1)]
    [SerializeField]
    private float speed;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Player") return;
        
        _isGettingBigger = true;
    }

    private void Update()
    {
        if (!_isGettingBigger) return;
        
        _camera.orthographicSize = Mathf.Lerp(6, 12, _time);
        _time += Time.deltaTime * speed;
    }
}