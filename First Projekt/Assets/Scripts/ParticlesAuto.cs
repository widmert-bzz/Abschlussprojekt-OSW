using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesAuto : MonoBehaviour
{
    public ParticleSystem Blood;
    private float timer;
    void Start()
    {
        Blood.Play();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 2)
            Destroy(gameObject);
    }


}
