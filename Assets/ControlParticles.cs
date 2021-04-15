using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlParticles : MonoBehaviour
{
    public Transform particles;
    // Start is called before the first frame update
    void Start()
    {
        particles.GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("down"))
        {
            particles.GetComponent<ParticleSystem>().enableEmission = true;
        }
    }
}
