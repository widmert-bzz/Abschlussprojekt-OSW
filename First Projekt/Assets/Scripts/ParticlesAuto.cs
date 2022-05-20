using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesAuto : MonoBehaviour
{
    public ParticleSystem Blood;
    void Start()
    {
        Blood.Play();
    }
    private void Update()
    {
        if (Time.deltaTime > 2)
            Destroy(gameObject);
    }


}
