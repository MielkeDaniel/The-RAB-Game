using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstIntervall : MonoBehaviour
{
    private ParticleSystem vfx;
    
    void Start()
    {
        vfx = GetComponent<ParticleSystem>();
        // Start the intervall in which the particle effect will be turned on and off
        InvokeRepeating("SpyFire", 2f, 2f);
    }

    // Based on the current state of the particle effect, turn it on if it´s inactive and off if it´s active
    void SpyFire() {
        var emission = vfx.emission;
        if (emission.enabled) {
            emission.enabled = false;
        } else {
            emission.enabled = true;
        }
    }
}
