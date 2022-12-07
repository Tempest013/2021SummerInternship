using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDieOverTime : MonoBehaviour
{

   private ParticleSystem system;
    private void Start()
    {
        system = GetComponent<ParticleSystem>();

    }


    // Update is called once per frame
    void Update()
    {
        if (!system.IsAlive())
            Destroy(gameObject);
    }
}
