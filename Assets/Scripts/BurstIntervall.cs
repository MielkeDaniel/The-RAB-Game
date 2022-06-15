using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstIntervall : MonoBehaviour
{
    private ParticleSystem vfx;
    // Start is called before the first frame update
    void Start()
    {
        vfx = GetComponent<ParticleSystem>();
        InvokeRepeating("SpyFire", 3f, 1f);
    }

    void SpyFire() {
        var emission = vfx.emission;
        if (emission.enabled) {
            emission.enabled = false;
        } else {
            emission.enabled = true;
        }
    }
}
