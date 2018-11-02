using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesPile : MonoBehaviour {

    public ParticleSystem part01;
    public ParticleSystem part02;
    public ParticleSystem part03;

    private void Awake()
    {
        part01.Pause();
        part02.Pause();
        part03.Pause();
    }

    void EmitParticles()
    {
        part01.Play();
        part02.Play();
        part03.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        EmitParticles();
    }

}
