using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem pparticles;
    void OnCollisionEnter2D(Collision2D other)
    {
        pparticles.Play();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        pparticles.Stop();
    }
}
